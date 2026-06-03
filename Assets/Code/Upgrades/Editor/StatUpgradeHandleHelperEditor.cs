using UnityEditor;
using UnityEngine;

namespace Code.Upgrades.Editor
{
    [CustomEditor(typeof(StatUpgradeHandleHelper))]
    public sealed class StatUpgradeHandleHelperEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            StatUpgradeHandleHelper helper = (StatUpgradeHandleHelper)target;

            if (GUILayout.Button("Use Upgrade"))
            {
                helper.Apply();
            }
        }
    }
}