using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevolutionGames
{
    public class MobileHeliInput : KeyboardHeliInput
    {
        #region Cutom Methods
        protected override void HandleThrottle()
        {
            //throttleInput = Input.GetAxis("XboxThrottleUp") + -Input.GetAxis("XboxThrottleDown");
        }

        protected override void HandleCollective()
        {
            //collectiveInput = Input.GetAxis("XboxCollective");
            //collectiveInput = -Input.acceleration.y;
        }

        protected override void HandleCyclic()
        {
            //cyclicInput.y = Input.GetAxis("XboxCyclicVertical");
            //cyclicInput.x = Input.GetAxis("XboxCyclicHorizontal");
            cyclicInput.x = Input.acceleration.x;
            cyclicInput.y = Input.acceleration.y;
        }

        protected override void HandlePedal()
        {
            //pedalInput = Input.GetAxis("XboxPedal");
            pedalInput = Input.acceleration.x;
        }

        protected override void HandleCamButton()
        {
            //camInput = Input.GetButtonDown("XboxCamBtn");
        }

        protected override void HandleFireButton()
        {
            //fire = Input.GetButton("XboxFireBtn");
        }

        public void OnFireButtonClicked()
        {
            fire = true;
        }
        #endregion
    }
}
