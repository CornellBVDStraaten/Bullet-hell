using UnityEngine;

namespace Enemies.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        private GameManager gameManager;
        public GameObject enemyPrefab;      // The enemy to spawn (drag in from Assets)
        public Transform[] spawnPoints;     // Array of places enemies can spawn
        public float spawnInterval = 5f;    // Time between spawns
        
        void Start()
        {
            gameManager = GameManager.Instance;

            InvokeRepeating(nameof(SpawnEnemy), 2f, spawnInterval);
        }

        void SpawnEnemy()
        {
            if (!gameManager.IsWaveActive()) {
                return;
            }

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            BaseEnemy baseEnemy = spawnedEnemy.GetComponent<BaseEnemy>();
            if (baseEnemy != null) {
                int healthBoost = 10 * gameManager.GetWave();
                baseEnemy.BoostHealth(healthBoost);
            }
        }
    }
}
