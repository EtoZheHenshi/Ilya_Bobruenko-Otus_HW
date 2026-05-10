using System.Linq;
using UnityEngine;

namespace Code.Enemies
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy[] enemyPrefabs;

        public void Spawn(EnemyType enemyType)
        {
            Enemy enemy = enemyPrefabs.First(n => n.Type == enemyType);

            if (enemy != null)
            {
                Instantiate(enemy, transform.position, transform.rotation, transform);
            }
        }
    }
}