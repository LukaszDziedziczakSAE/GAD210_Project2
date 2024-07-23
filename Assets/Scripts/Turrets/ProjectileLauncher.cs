using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float fireRate = 0.5f;

    float lastFireTime = Mathf.NegativeInfinity;
    float timeSinceLastFire => Time.time - lastFireTime;

    public void Fire()
    {
        if (timeSinceLastFire < fireRate) return;

        Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        lastFireTime = Time.time;
        //Debug.Log("Firing");
    }
}
