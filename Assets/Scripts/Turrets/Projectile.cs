using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float timeToLive = 50;
    [SerializeField] float damage = 10;
    [SerializeField] Ship owner;
    [SerializeField] Impact impactPrefab;

    float birthTime;
    float timeAlive => Time.time - birthTime;
    public float Speed => speed;


    private void Start()
    {
        birthTime = Time.time;
        //print(name + " spawned");
    }

    private void Update()
    {
        if (timeAlive > timeToLive) Destroy(gameObject);

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(name + " hit " + other.name);
        if (other.tag == "Turret") return;
        if (other.TryGetComponent<Ship>(out Ship ship))
        {
            if (owner == ship) return;
            ship.Health.ApplyDamage(damage);

            Instantiate(impactPrefab, transform.position, transform.rotation);

            Destroy(gameObject);
        }

        
    }

    public void Initilize(float damageAmount, Ship owner, Vector3 target)
    {
        damage = damageAmount;
        this.owner = owner;
        //print(name + " initilized");

        transform.LookAt(target);
    }
}
