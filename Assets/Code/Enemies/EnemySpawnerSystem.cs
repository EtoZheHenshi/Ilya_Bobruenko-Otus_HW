using UnityEngine;

namespace Code.Enemies
{
    public sealed class EnemySpawnerSystem : MonoBehaviour
    {
        [SerializeField] private EnemySpawner[] groundSpawners;
        [SerializeField] private EnemySpawner[] airSpawners;

        public void Initialize()
        {
            
        }
    }
}