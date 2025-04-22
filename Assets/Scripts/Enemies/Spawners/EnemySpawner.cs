using UnityEngine;

namespace Enemies.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;      // The enemy to spawn (drag in from Assets)
        public Transform[] spawnPoints;     // Array of places enemies can spawn
        public float spawnInterval = 5f;    // Time between spawns
        
        void Start()
        {
            InvokeRepeating(nameof(SpawnEnemy), 2f, spawnInterval);
        }

        void SpawnEnemy()
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
