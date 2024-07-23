using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    Turret turret;
    List<EnemyShip> enemyShips = new List<EnemyShip>();

    private void Awake()
    {
        turret = GetComponentInParent<Turret>();
    }

    private void Update()
    {
        if (turret.State != Turret.EState.Built) return;

        if (enemyShips.Count > 0)
        {
            turret.ProjectileLauncher.Fire();

            foreach (EnemyShip enemyShip in enemyShips.ToArray())
            {
                if (enemyShip == null) enemyShips.Remove(enemyShip);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (turret.State != Turret.EState.Built) return;

        if (other.TryGetComponent<EnemyShip>(out EnemyShip enemyShip))
        {
            enemyShips.Add(enemyShip);
            Debug.Log(turret.name + " has enemy ship in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (turret.State != Turret.EState.Built) return;

        if (other.TryGetComponent<EnemyShip>(out EnemyShip enemyShip))
        {
            enemyShips.Remove(enemyShip);
        }
    }
}
