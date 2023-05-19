using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevolutionGames
{
    public class MissileWeapon : BaseProjectile
    {
        #region Variables
        [Header("Missile  Properties")]
        public Transform explosionParticle;
      
        #endregion

        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            col = GetComponent<CapsuleCollider>();
            //col.isTrigger = true;
        }
        #endregion

        #region Custom Methods
        public override void FireProjectile()
        {
            //base.FireProjectile();
            startTime = Time.time;
            GetComponent<Rigidbody>().AddForce(transform.up * projectileSpeed, ForceMode.Impulse);
            if (transform.childCount != 0)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        #endregion

        #region Collision Methods
        /*public void OnTriggerEnter(Collider other)
        {
            print("missile trigger");
            if(explosionParticle)
            {
                Instantiate(explosionParticle, other.transform.position, other.transform.rotation);
                Destroy(this.gameObject);
            }
        }*/
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(this.gameObject);
        }
        #endregion
    }
}
