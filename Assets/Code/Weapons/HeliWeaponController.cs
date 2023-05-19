using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace RevolutionGames
{
    public class HeliWeaponController : MonoBehaviour
    {
        #region Variables
        [Header("Weapon Controller Properties")]
        public bool allowFiring = true;

        [Space]
        [Header("Missile properties")]
        public GameObject missilePrefab;
        public GameObject blastPrefab;

        private List<IWeapon> weapons = new List<IWeapon>();
        private LeftSideGunWeapon leftSideGun = null;

        private List<Transform> missileLaunchPositions = new List<Transform>();
        #endregion


        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {
            for(int i = 0;i<transform.childCount;i++)
            {
                if (transform.GetChild(i).GetComponent<LeftSideGunWeapon>() != null)
                {
                    leftSideGun = transform.GetChild(i).GetComponent<LeftSideGunWeapon>();
                }
                else if (transform.GetChild(i).GetComponent<IWeapon>() != null)
                {
                    weapons.Add(transform.GetChild(i).GetComponent<IWeapon>());
                }
            }

            //Get missile rocket positions
            for(int i=0;i<transform.GetChild(2).childCount;i++)
            {
                missileLaunchPositions.Add(transform.GetChild(2).GetChild(i));
            }
            for (int i = 0; i < transform.GetChild(4).childCount; i++)
            {
                missileLaunchPositions.Add(transform.GetChild(4).GetChild(i));
            }

            //Load missiles for the launch positions
            //StartCoroutine(AddMissilesToPosition());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                /*if (missileLaunchPositions.Count != 0)
                {
                    missileLaunchPositions[0].transform.GetComponent<MissileWeapon>().FireProjectile();
                    missileLaunchPositions.RemoveAt(0);
                }*/
                FireMissile();
            }
        }
        #endregion


        #region Custom Methods
        public void UpdateWeapons(InputController input)
        {
            if (input.Fire)
            {
                if (weapons.Count > 0 && allowFiring)
                {
                    foreach (IWeapon weapon in weapons)
                    {
                        weapon.FireWeapon();
                    }
                }
            }
            else if (input.LeftSideFire && allowFiring)
            {
                leftSideGun.FireWeapon();
            }
        }

        /*IEnumerator AddMissilesToPosition()
        {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < missileLaunchPositions.Count; i++)
            {
                Instantiate(missilePrefab, missileLaunchPositions[i]);
                //missileLaunchPositions[i].gameObject.AddComponent<MissileWeapon>();
                //missileLaunchPositions[i].transform.GetComponent<Rigidbody>().useGravity = false;
                //missileLaunchPositions[i].transform.GetComponent<MissileWeapon>().projectileSpeed = 50;
                //missileLaunchPositions[i].transform.GetComponent<MissileWeapon>().explosionParticle = blastPrefab.transform;
            }
        }*/

        void FireMissile()
        {
            if (missileLaunchPositions.Count != 0)
            {
                missileLaunchPositions[0].gameObject.AddComponent<MissileWeapon>();
                missileLaunchPositions[0].transform.GetComponent<Rigidbody>().useGravity = false;
                missileLaunchPositions[0].transform.GetComponent<MissileWeapon>().projectileSpeed = 50;
                missileLaunchPositions[0].transform.GetComponent<MissileWeapon>().explosionParticle = blastPrefab.transform;
                missileLaunchPositions[0].transform.GetComponent<MissileWeapon>().FireProjectile();
                missileLaunchPositions.RemoveAt(0);
            }
        }
        #endregion
    }
}
