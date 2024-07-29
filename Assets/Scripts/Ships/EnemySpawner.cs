using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyShip enemyPrefab;

    [SerializeField] float spawnTimer;
    [SerializeField] float spawnTime = 3.0f;
    [SerializeField] Transform[] spawner;


    private void Start()
    {
        spawnTimer = spawnTime;
        //SpawnEnemy();
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnEnemy();
            ResetTimer();
        }
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab not set on spawner");
            return;
        }

        int randomSpawnPoint = Random.Range(0, spawner.Length);
        EnemyShip enemyShip = Instantiate(enemyPrefab, spawner[randomSpawnPoint].transform.position, Quaternion.identity);
        enemyShip.AI.SetNavSystem(Game.Mothership.RandomPair);
        enemyShip.name = "Enemy" + Random.Range(100, 1000);
    }

    void ResetTimer()
    {
        spawnTimer = spawnTime;
    }

}
