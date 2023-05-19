using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevolutionGames
{
    public class GatlingGunWeapon : RapidFireWeapon
    {
        #region Variables
        [Header("Gatling Gun Properties")]
        public Transform barrelGo;
        public float rotationSpeed = 10f;
        public float slowDownSpeed = 5f;

        private float lastRotSpeed = 0f;
        #endregion

        #region Built in Methods
        private void Update()
        {
            if(barrelGo)
            {
                lastRotSpeed -= Time.deltaTime * slowDownSpeed;
                lastRotSpeed = Mathf.Clamp(lastRotSpeed, 0f, rotationSpeed);
                barrelGo.Rotate(Vector3.up, lastRotSpeed);
            }
        }
        #endregion

        #region Override Methods
        public override void FireWeapon()
        {
            base.FireWeapon();
            if(barrelGo)
            {
                barrelGo.Rotate(Vector3.up, rotationSpeed);
                lastRotSpeed = rotationSpeed;
            }
        }
        #endregion
    }
}
