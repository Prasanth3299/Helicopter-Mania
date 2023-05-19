using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevolutionGames
{
    public class BaseHeliInput : MonoBehaviour
    {
        #region Variables
        [Header("Base Input Properties")]
        protected float vertical = 0f;
        protected float horizontal = 0f;
        #endregion


        #region BuiltIn Methods
        void Update()
        {
            HandleInputs();
        }
        #endregion


        #region Custom Methods
        protected virtual void HandleInputs()
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
        }
        #endregion
    }
}
