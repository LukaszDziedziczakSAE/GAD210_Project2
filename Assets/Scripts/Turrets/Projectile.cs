using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float timeToLive = 50;
    [SerializeField] float damage = 10;

    float birthTime;
    float timeAlive => Time.time - birthTime;

    private void Start()
    {
        birthTime = Time.time;
    }

    private void Update()
    {
        if (timeAlive > timeToLive) Destroy(gameObject);

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyShip>(out EnemyShip enemyShip))
        {
            Destroy(enemyShip.gameObject);
        }


        Destroy(gameObject);
    }

    public void SetDamage(float amount)
    {
        damage = amount;
    }
}
