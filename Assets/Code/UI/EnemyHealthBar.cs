using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RevolutionGames
{

    public class EnemyHealthBar : BaseEnemyBehaviour,IEnemyBehaviour
    {

        #region Interface Override Methods

        // change health bar color
        public  override void UpdateSlideColor()
        {
            base.UpdateSlideColor();
        }
        protected override void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);
        }
   
        #endregion

    }
}
