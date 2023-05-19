using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RevolutionGames
{

    public class SideViewHeliCamera :BaseHeliCamera,IHeliCamera
    {
        #region Variables
        [Header("side view Camera Properties")]
        public Transform targetPosition;
        public Transform cameraManager;

        #endregion

        #region builtin Methods

        public void OnEnable()
        {
            updateEvent.AddListener(UpdateCamera);
        }
        public void OnDisable()
        {
            updateEvent.RemoveListener(UpdateCamera);
        }

        #endregion


        #region Custom Methods

        //set camera parent
        void AddSideCameraParent()
        {
            if (transform.parent != targetPosition)
            {
                transform.parent = targetPosition;
                transform.localRotation = Quaternion.identity;
                transform.localPosition = Vector3.zero;
            }
        }
        //delete camera parent
        void DeleteSideCameraParent()
        {
            if (transform.parent == targetPosition)
            {
                transform.parent = cameraManager;
            }
        }
        #endregion

        #region Interface Methods
        public void UpdateCamera()
        {
            AddSideCameraParent();

        }

        #endregion

    }
}

