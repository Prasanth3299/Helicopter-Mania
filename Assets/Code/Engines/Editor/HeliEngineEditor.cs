using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RevolutionGames
{
    [CustomEditor(typeof(HeliEngine))]
    public class HeliEngineEditor : Editor
    {
        #region Variables
        private HeliEngine targetEngine;
        #endregion

        #region Builtin Methods
        private void OnEnable()
        {
            targetEngine = (HeliEngine)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(10);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Engine Stats:", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("RPM's: " + targetEngine.CurrentRPM);
            EditorGUILayout.LabelField("HP: " + targetEngine.CurrentHP);

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();

            Repaint();
        }
        #endregion
    }
}
