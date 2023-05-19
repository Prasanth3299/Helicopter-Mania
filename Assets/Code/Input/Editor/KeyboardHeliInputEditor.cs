using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RevolutionGames
{
    [CustomEditor(typeof(KeyboardHeliInput))]
    public class KeyboardHeliInputEditor : Editor
    {
        #region Variables
        KeyboardHeliInput targetInput;
        #endregion


        #region Builtin Methods
        private void OnEnable()
        {
            targetInput = (KeyboardHeliInput)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DrawDebugUI();

            Repaint();
        }
        #endregion


        #region Custom Methods
        void DrawDebugUI()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.Space();

            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Throttle: " + targetInput.RawThrottleInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Collective: " + targetInput.CollectiveInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Cyclic: " + targetInput.CyclicInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Pedal: " + targetInput.PedalInput.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUI.indentLevel--;

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();
        }
        #endregion
    }
}
