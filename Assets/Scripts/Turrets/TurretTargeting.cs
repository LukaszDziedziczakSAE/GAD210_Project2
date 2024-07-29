using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    Turret turret;
    List<Ship> inRange = new List<Ship>();

    private void Awake()
    {
        turret = GetComponentInParent<Turret>();
    }

    private void Update()
    {
        if (turret.State != Turret.EState.Built) return;

        if (inRange.Count > 0)
        {
            turret.Fire();

            foreach (Ship enemyShip in inRange.ToArray())
            {
                if (enemyShip == null) inRange.Remove(enemyShip);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(name + " OnTriggerEnter");

        if (turret.State != Turret.EState.Built)
        {
            Debug.Log(name + " is in " + turret.State + " state");
            return;
        }

        if (other.TryGetComponent<Ship>(out Ship ship))
        {
            inRange.Add(ship);
            Debug.Log(turret.name + " has enemy ship in range");
        }
        else
        {
            Debug.Log(turret.name + " has " + other.name + "in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (turret.State != Turret.EState.Built) return;

        if (other.TryGetComponent<Ship>(out Ship ship))
        {
            inRange.Remove(ship);
        }
    }
}
