using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyShip enemyPrefab;
    [SerializeField] float height;
    [SerializeField] float width;
    [SerializeField] float spawnTimer;
    [SerializeField] float spawnTime = 3.0f;
    [SerializeField] float waveCooldown;
    [SerializeField] Wave[] waves;
    [SerializeField] CapitalShip targetShip;

    int waveIndex;
    float waveTimer;
    Wave currentWave => waves[waveIndex];

    public enum EDirection
    {
        Top,
        Bottom,
        Left,
        Right
    }

    private void Start()
    {
        spawnTimer = spawnTime;
        Health.OnDeath += OnShipDeath;
    }

    private void OnDisable()
    {
        Health.OnDeath -= OnShipDeath;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        transform.position = new Vector3(Game.Mothership.transform.position.x, transform.position.y, Game.Mothership.transform.position.z);

        if (waveTimer > 0)
        {
            waveTimer -= Time.deltaTime;
            return;
        }

        if (waveIndex >= waves.Length) return;

        if (currentWave.SpawnedEnemies < currentWave.EnemiesToSpawn)
        {
            if (spawnTimer <= 0)
            {
                SpawnEnemy();
                currentWave.SpawnedEnemies++;
                ResetTimer();
            }
        }

        if (currentWave.EnemiesRemaining == 0)
        {
            waveIndex++;
            waveTimer = waveCooldown;
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int EnemiesToSpawn;
        public int SpawnedEnemies;
        public int DestoryedEnemies;

        public int EnemiesRemaining => EnemiesToSpawn - DestoryedEnemies;
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab not set on spawner");
            return;
        }

        EnemyShip enemyShip = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        if (Game.Mothership != null) enemyShip.AI.SetNavSystem(targetShip.RandomPair);
        enemyShip.name = "Enemy" + Random.Range(100, 1000);
    }

    void ResetTimer()
    {
        spawnTimer = spawnTime;
    }

    private Vector3 spawnLocation
    {
        get
        {
            EDirection direction = (EDirection)Random.Range(0, 4);

            switch (direction)
            {
                case EDirection.Top:
                    float xTop = Random.Range(transform.position.x - width, transform.position.x + width);
                    float zTop = height;
                    return new Vector3(xTop, 0, zTop);

                case EDirection.Bottom:
                    float xBottom = Random.Range(transform.position.x - width, transform.position.x + width);
                    float zBottom = -height;
                    return new Vector3(xBottom, 0, zBottom);

                case EDirection.Left:
                    float xLeft = -width;
                    float zLeft = Random.Range(transform.position.x - height, transform.position.x + height);
                    return new Vector3(xLeft, 0, zLeft);

                case EDirection.Right:
                    float xRight = width;
                    float zRight = Random.Range(transform.position.x - height, transform.position.x + height);
                    return new Vector3(xRight, 0, zRight);

                default:
                    return Vector3.zero;
            }
        }
    }

    private void OnShipDeath(Ship ship)
    {
        if (ship.TryGetComponent<EnemyShip>(out EnemyShip enemyShip))
        {
            currentWave.DestoryedEnemies++;
        }
    }
}
