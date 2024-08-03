using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] CapitalShip targetShip;
    [SerializeField] EnemyShip enemyPrefab;
    [SerializeField] float height;
    [SerializeField] float width;
    [SerializeField] float spawnTime = 3.0f;
    [SerializeField] float waveCooldown;
    [SerializeField] Wave[] waves;

    [Header("Debug")]
    [SerializeField] float spawnTimer;
    [SerializeField] int spawnedEnemies;
    [SerializeField] int destoryedEnemies;
    [SerializeField] int waveIndex;
    [SerializeField] float waveTimer;

    Wave currentWave => waves[waveIndex];
    bool firstSpawned = true;
    int enemiesRemaining => currentWave.EnemiesToSpawn - destoryedEnemies;

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
        if (spawnTimer > 0) spawnTimer -= Time.deltaTime;
        //transform.position = new Vector3(Game.Mothership.transform.position.x, transform.position.y, Game.Mothership.transform.position.z);

        if (waveTimer > 0)
        {
            waveTimer -= Time.deltaTime;
            return;
        }

        if (waveIndex >= waves.Length) return;

        if (spawnedEnemies < currentWave.EnemiesToSpawn && spawnTimer <= 0)
        {
            SpawnEnemy();
        }

        if (enemiesRemaining == 0)
        {
            spawnedEnemies = 0;
            destoryedEnemies = 0;
            waveIndex++;
            waveTimer = waveCooldown;
            firstSpawned = false;
            
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int EnemiesToSpawn = 10;
        public float Health = 30;
        public float Damage = 10;
        public int Reward = 10;
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab not set on spawner");
            return;
        }

        Vector3 spawnLocation = GenerateSpawnLocation();
        Vector3 directionOfSpawn = Game.Mothership.transform.position - spawnLocation;
        if ( directionOfSpawn.x < -width || directionOfSpawn.x > width || directionOfSpawn.z < -height || directionOfSpawn.z > height )
        {
            Debug.LogError("Spawn Error " + new Vector2(directionOfSpawn.x, directionOfSpawn.z).ToString());

            return;
        }
        

        EnemyShip enemyShip = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        if (Game.Mothership != null) enemyShip.AI.SetNavSystem(targetShip.RandomPair);
        enemyShip.name = "Enemy" + UnityEngine.Random.Range(100, 1000);
        enemyShip.Health.SetMaxHealth(currentWave.Health);
        enemyShip.Turret.SetFirepower(currentWave.Damage);
        enemyShip.GetComponent<ResourceOnDeath>().SetReward(currentWave.Reward);

        //Debug.Log("Spawned " + enemyShip.name + " " + Vector3.Distance(enemyShip.transform.position, Game.Mothership.transform.position).ToString("F0") + " away from mothership " + directionOfSpawn.ToString());
        
        spawnedEnemies++;
        spawnTimer = spawnTime;

        if (!firstSpawned)
        {
            firstSpawned = true;
            Game.PlayStartSound();
        }
    }

    private Vector3 spawnLocation
    {
        get
        {
            EDirection direction = (EDirection)UnityEngine.Random.Range(0, 4);

            switch (direction)
            {
                case EDirection.Top:
                    float xTop = UnityEngine.Random.Range(origin.x - width, origin.x + width);
                    float zTop = height;
                    return new Vector3(xTop, 0, zTop);

                case EDirection.Bottom:
                    float xBottom = UnityEngine.Random.Range(origin.x - width, origin.x + width);
                    float zBottom = -height;
                    return new Vector3(xBottom, 0, zBottom);

                case EDirection.Left:
                    float xLeft = -width;
                    float zLeft = UnityEngine.Random.Range(origin.z - height, origin.z + height);
                    return new Vector3(xLeft, 0, zLeft);

                case EDirection.Right:
                    float xRight = width;
                    float zRight = UnityEngine.Random.Range(origin.z - height, origin.z + height);
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
            destoryedEnemies++;
        }
    }

    private Vector3 origin
    {
        get
        {
            return Game.Mothership.transform.position;
        }
    }

    private Vector3 GenerateSpawnLocation()
    {
        Vector3 spawnLocation = Game.Mothership.transform.position;
        spawnLocation.y = 0;

        EDirection direction = (EDirection)UnityEngine.Random.Range(0, 4);

        switch (direction)
        {
            case EDirection.Top:
                spawnLocation.x += UnityEngine.Random.Range(-width, width);
                spawnLocation.z += height;
                break;

            case EDirection.Bottom:
                spawnLocation.x += UnityEngine.Random.Range(-width, width);
                spawnLocation.z += -height;
                break;

            case EDirection.Left:
                spawnLocation.x += -width;
                spawnLocation.z += UnityEngine.Random.Range(-height, height);
                break;

            case EDirection.Right:
                spawnLocation.x += width;
                spawnLocation.z += UnityEngine.Random.Range(-height, height);
                break;
        }

        return spawnLocation;
    }
}
