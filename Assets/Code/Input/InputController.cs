using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RevolutionGames
{
    public enum InputType
    {
        Keyboard,
        Xbox,
        Mobile,
    }
    [RequireComponent(typeof(KeyboardHeliInput), typeof(XboxHeliInput), typeof(MobileHeliInput))]
    public class InputController : MonoBehaviour
    {
        #region Variables
        [Header("Input Properties")]
        public InputType inputType = InputType.Keyboard;

        [Header("Input Events")]
        public UnityEvent onCamButtonPressed = new UnityEvent();

        private KeyboardHeliInput keyInput;
        private XboxHeliInput xboxInput;
        private MobileHeliInput mobileInput;

        private float throttleInput;
        public float ThrottleInput
        {
            get { return throttleInput; }
        }

        private float stickyThrottle;
        public float StickyThrottle
        {
            get { return stickyThrottle; }
        }

        private float collectiveInput;
        public float CollectiveInput
        {
            get { return collectiveInput; }
        }

        private float stickyCollectiveInput;
        public float StickyCollectiveInput
        {
            get { return stickyCollectiveInput; }
        }


        private Vector2 cyclicInput;
        public Vector2 CyclicInput
        {
            get { return cyclicInput; }
        }

        private float pedalInput;
        public float PedalInput
        {
            get { return pedalInput; }
        }

        private bool camInput;
        public bool CamInput
        {
            get { return camInput; }
        }

        private bool fire;
        public bool Fire
        {
            get { return fire; }
        }

        private bool leftSideFire;
        public bool LeftSideFire
        {
            get { return leftSideFire; }
        }
        #endregion



        #region Buitlin Methods
        void Start()
        {
            keyInput = GetComponent<KeyboardHeliInput>();
            xboxInput = GetComponent<XboxHeliInput>();
            mobileInput = GetComponent<MobileHeliInput>();
            if (keyInput && xboxInput && mobileInput)
            {
                SetInputType(inputType);
            }
        }

        private void Update()
        {
            if (keyInput && xboxInput && mobileInput)
            {
                switch (inputType)
                {
                    case InputType.Keyboard:
                        throttleInput = keyInput.RawThrottleInput;
                        collectiveInput = keyInput.CollectiveInput;
                        stickyCollectiveInput = keyInput.StickyCollectiveInput;
                        cyclicInput = keyInput.CyclicInput;
                        pedalInput = keyInput.PedalInput;
                        stickyThrottle = keyInput.StickyThrottle;
                        camInput = keyInput.CamInput;
                        fire = keyInput.Fire;
                        leftSideFire = keyInput.LeftSideFire;
                        break;

                    case InputType.Xbox:
                        throttleInput = xboxInput.RawThrottleInput;
                        collectiveInput = xboxInput.CollectiveInput;
                        stickyCollectiveInput = xboxInput.StickyCollectiveInput;
                        cyclicInput = xboxInput.CyclicInput;
                        pedalInput = xboxInput.PedalInput;
                        stickyThrottle = xboxInput.StickyThrottle;
                        camInput = xboxInput.CamInput;
                        fire = xboxInput.Fire;
                        break;

                    case InputType.Mobile:
                        throttleInput = mobileInput.RawThrottleInput;
                        collectiveInput = mobileInput.CollectiveInput;
                        stickyCollectiveInput = mobileInput.StickyCollectiveInput;
                        cyclicInput = mobileInput.CyclicInput;
                        pedalInput = mobileInput.PedalInput;
                        stickyThrottle = mobileInput.StickyThrottle;
                        camInput = mobileInput.CamInput;
                        fire = mobileInput.Fire;
                        break;

                    default:
                        break;
                }

                if (camInput)
                {
                    onCamButtonPressed.Invoke();
                }
            }
        }
        #endregion



        #region Custom Methods
        void SetInputType(InputType type)
        {
            if (type == InputType.Keyboard)
            {
                keyInput.enabled = true;
                xboxInput.enabled = false;
                mobileInput.enabled = false;
            }

            if (type == InputType.Xbox)
            {
                xboxInput.enabled = true;
                keyInput.enabled = false;
                mobileInput.enabled = false;
            }

            if (type == InputType.Xbox)
            {
                xboxInput.enabled = false;
                keyInput.enabled = false;
                mobileInput.enabled = true;
            }
        }
        #endregion
    }
}
