using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] asteroidPrefabs;
    [SerializeField] Vector2 heightRange;
    [SerializeField] float heighSize;
    [SerializeField] float widthSize;
    [SerializeField] Vector2 verticalDistanceBetweenRange;
    [SerializeField] Vector2 horizontalDistanceBetweenRange;
    [SerializeField] Vector2 wobbleRange;

    [field: SerializeField] public bool SpawningComplete {  get; private set; }
    private float minX => -widthSize;
    private float maxX => widthSize;
    private float minZ => -heighSize;   
    private float maxZ => heighSize;
    private float horizontalDistanceBetween => Random.Range(verticalDistanceBetweenRange.x, verticalDistanceBetweenRange.y);
    private float verticalDistanceBetween => Random.Range(horizontalDistanceBetweenRange.x, horizontalDistanceBetweenRange.y);
    private GameObject asteroidPrefab => asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
    private float randomHeight => Random.Range(heightRange.x, heightRange.y);
    private GameObject lastSpawned;
    private float count;
    private Vector2 lastSpawnLocation => new Vector2(lastSpawned.transform.position.x, lastSpawned.transform.position.z);
    private float timer;

    private Quaternion randomRotation
    {
        get
        {
            float randomX = Random.Range(0, 360);
            float randomY = Random.Range(0, 360);
            float randomZ = Random.Range(0, 360);

            return Quaternion.Euler(randomX, randomY, randomZ);
        }
    }

    private Vector2 nextSpawnLocation
    {
        get
        {
            Vector2 location = lastSpawnLocation;
            location.x += horizontalDistanceBetween;

            if (location.x > maxX)
            {
                location.y += verticalDistanceBetween;
                location.x = (minX + wobble);
            }
            else
            {
                location.y += wobble;
            }

            return location;
        }
    }

    private float wobble => Random.Range(wobbleRange.x, wobbleRange.y);

    private void Start()
    {
    }

    private void Update()
    {
        if (!SpawningComplete) SpawnAsteroids();
    }

    private void SpawnAsteroids()
    {
        timer += Time.deltaTime;

        if (lastSpawned == null)
        {
            SpawnAsteroid(new Vector2(minX, minZ));
            return;
        }

        else if (lastSpawnLocation.y < maxZ)
        {
            SpawnAsteroid(nextSpawnLocation);
        }

        else
        {
            SpawningComplete = true;
            Debug.Log("Spawned " + count + " asteroid objects in " + timer + " seconds");
        }
    }


    private void SpawnAsteroid(Vector2 position)
    {
        GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(position.x, randomHeight, position.y), randomRotation);
        asteroid.name = "AsteroidField" + (++count).ToString();
        asteroid.transform.parent = transform;
        lastSpawned = asteroid;
    }
}
