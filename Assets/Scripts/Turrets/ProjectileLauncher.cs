using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    Ship owner;
    Turret turret;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float fireRate = 0.5f;

    float lastFireTime = Mathf.NegativeInfinity;
    float timeSinceLastFire => Time.time - lastFireTime;

    public float ProjectileSpeed => projectilePrefab.Speed;

    private void Awake()
    {
        turret = GetComponent<Turret>();
        owner = GetComponentInParent<Ship>();
    }

    public void Fire(Vector3 target)
    {
        if (timeSinceLastFire < fireRate) return;

        Projectile projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        projectile.Initilize(turret.Damage, owner, target);
        lastFireTime = Time.time;
        //Debug.Log("Firing");
    }

    public bool CanFire => timeSinceLastFire >= fireRate;

    public void SetFireRate(float newRate)
    {
        fireRate = newRate;
    }
}
