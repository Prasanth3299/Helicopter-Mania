using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevolutionGames
{
    public class RapidFireWeapon : BaseWeapon, IWeapon
    {
        #region Variables
        [Header("Rapid Fire Properties")]
        public float fireRate = 0.15f;

        private float lastFireTime = 0f;
        #endregion


        #region Override Methods
        public override void FireWeapon()
        {
            if (Time.time >= lastFireTime + fireRate)
            {
                Fire();
                lastFireTime = Time.time;
            }
        }
        #endregion
    }
}
