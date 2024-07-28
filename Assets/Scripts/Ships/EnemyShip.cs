using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShip : Ship
{
    Waypoint[] Waypoint;
    Waypoint NearestWaypoint;

    float distance;
    float nearestDistance = 1000f;

    private void Start()
    {
        Waypoint = FindObjectsOfType<Waypoint>();

        for (int i = 0; i < Waypoint.Length; i++)
        {
            distance = Vector3.Distance(transform.position, Waypoint[i].transform.position);
            if (distance < nearestDistance)
            {
                NearestWaypoint = Waypoint[i];
                nearestDistance = distance;

                ShipMovement.SetTargetWaypoint(NearestWaypoint);
            }
        }
    }



}
