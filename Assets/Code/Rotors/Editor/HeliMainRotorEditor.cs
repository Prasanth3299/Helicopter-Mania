using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RevolutionGames
{
    [CustomEditor(typeof(HeliMainRotor))]
    public class HeliMainRotorEditor : Editor
    {
        #region Variables
        private HeliMainRotor targetRotor;
        #endregion

        #region BuiltIn Methods
        private void OnEnable()
        {
            targetRotor = (HeliMainRotor)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Repaint();
        }

        private void OnSceneGUI()
        {
            //Vector3 discNormal = Vector3.Normalize(targetRotor.transform.up + new Vector3(-targetRotor.cyclicVal.x, 0f, -targetRotor.cyclicVal.y) * 0.1f);

            //Handles.color = new Color(0f, 1f, 0f, 0.15f);
            //Handles.DrawSolidDisc(targetRotor.transform.position + (targetRotor.transform.up * 0.1f), discNormal, targetRotor.radius);

            //Handles.color = Color.green;
            //Handles.DrawWireDisc(targetRotor.transform.position + (targetRotor.transform.up * 0.1f), discNormal, targetRotor.radius);

            //Handles.color = Color.red;
            //Handles.ArrowHandleCap(0, targetRotor.lRotor.position, Quaternion.LookRotation(-targetRotor.transform.right), 1f, EventType.Repaint);
            //Handles.ArrowHandleCap(0, targetRotor.rRotor.position, Quaternion.LookRotation(targetRotor.transform.right), 1f, EventType.Repaint);

            //Repaint();
        }
        #endregion
    }
}
