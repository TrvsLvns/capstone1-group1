using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f;
    public int maxEnemies = 10;

    private float timeSinceLastSpawn;
    private int enemiesSpawned;

    void Start()
    {
        timeSinceLastSpawn = 0f;
        enemiesSpawned = 0;
    }

    void Update()
    {
        if (enemiesSpawned < maxEnemies)
        {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= spawnInterval)
            {
                SpawnEnemy();
                timeSinceLastSpawn = 0f;
            }
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null && spawnPoints.Length > 0)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

            Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                enemyRb.gravityScale = 0f;
            }

            enemiesSpawned++;
        }
        else
        {
            Debug.LogError("EnemyPrefab is not assigned or no SpawnPoints are defined in the EnemySpawner.");
        }
    }
}
