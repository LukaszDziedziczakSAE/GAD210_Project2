using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyShip enemy;

    [SerializeField] float spawnTimer;
    [SerializeField] float spawnTime = 3.0f;
    [SerializeField] Transform[] spawner;


    private void Start()
    {
        spawnTimer = spawnTime; 
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            SpawnEnemy(enemy);
            ResetTimer();
        }
    }

    public void SpawnEnemy(EnemyShip enemyShipPrefab)
    {
        int randomSpawnPoint = Random.Range(0, spawner.Length);
        Instantiate(enemyShipPrefab, spawner[randomSpawnPoint].transform.position, Quaternion.identity);
        
    }

    void ResetTimer()
    {
        spawnTimer = spawnTime;
    }

}
