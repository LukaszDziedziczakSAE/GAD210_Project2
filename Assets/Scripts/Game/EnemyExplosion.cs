using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    [SerializeField] float timeToLive = 5;

    float birthTime;
    float timeAlive => Time.time - birthTime;

    private void Start()
    {
        birthTime = Time.time;
    }

    private void Update()
    {
        if (timeAlive > timeToLive) Destroy(gameObject);
    }
}
