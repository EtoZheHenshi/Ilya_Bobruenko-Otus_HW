using UnityEditor;
using UnityEngine;

namespace Code.Enemies.Editor
{
    [CustomEditor(typeof(EnemySpawnerSystemHelper))]
    public class EnemySpawnerSystemHelperEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EnemySpawnerSystemHelper currencyViewHelper = (EnemySpawnerSystemHelper)target;

            if (GUILayout.Button("Spawn"))
            {
                currencyViewHelper.SpawnEnemy();
            }
        }
    }
}