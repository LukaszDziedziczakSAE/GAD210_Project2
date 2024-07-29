using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    Turret turret;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float fireRate = 0.5f;

    float lastFireTime = Mathf.NegativeInfinity;
    float timeSinceLastFire => Time.time - lastFireTime;

    private void Awake()
    {
        turret = GetComponent<Turret>();
    }

    public void Fire()
    {
        if (timeSinceLastFire < fireRate) return;

        Projectile projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        projectile.SetDamage(turret.Damage);
        lastFireTime = Time.time;
        //Debug.Log("Firing");
    }

    public bool CanFire => timeSinceLastFire >= fireRate;
}
