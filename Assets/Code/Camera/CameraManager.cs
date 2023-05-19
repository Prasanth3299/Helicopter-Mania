using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace RevolutionGames
{
    public class CameraManager : MonoBehaviour
    {
        #region Variables
        [Header("Manager Properties")]
        public int startIndex = 1;

        private List<BaseHeliCamera> cameras = new List<BaseHeliCamera>();
        private int camIndex = 0;
        #endregion



        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {
            cameras = transform.GetComponentsInChildren<BaseHeliCamera>().ToList<BaseHeliCamera>();
            camIndex = startIndex;

            SwitchCamera(camIndex);
        }
        #endregion



        #region Custom Methods
        public void SwitchCamera()
        {
            //Debug.Log("Switching Cameras!");
            camIndex++;
            HandleSwitch();
        }

        public void SwitchCamera(int index)
        {
            HandleSwitch();
        }

        private void HandleSwitch()
        {
            if (camIndex == cameras.Count)
            {
                camIndex = 0;
            }

            for (int i = 0; i < cameras.Count; i++)
            {
                //cameras[i].gameObject.SetActive(false);
                Camera curCam = cameras[i].GetComponent<Camera>();
                if (curCam)
                {
                    curCam.enabled = false;
                    if (i == camIndex)
                    {
                        //cameras[camIndex].gameObject.SetActive(true);
                        curCam.enabled = true;
                    }
                }
            }
        }
        #endregion
    }
}
