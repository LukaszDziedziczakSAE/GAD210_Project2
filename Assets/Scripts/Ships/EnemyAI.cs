using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    EnemyShip ship;
    Waypoint[] Waypoint;

    WaypointPair waypointPair;
    bool forward;

    Waypoint NearestWaypoint;

    float distance;
    float nearestDistance = 1000f;

    private void Awake()
    {
        ship = GetComponent<EnemyShip>();
    }

    private void Start()
    {
        ship.ShipMovement.OnArrived += OnArriveToWaypoint;
    }

    private void OnDisable()
    {
        ship.ShipMovement.OnArrived -= OnArriveToWaypoint;
    }

    public struct WaypointPair
    {
        public Waypoint FowardWaypoint;
        public Waypoint BackWaypoint;

        public Waypoint Closest(Vector3 origin)
        {
            float forwardDistance = Vector3.Distance(FowardWaypoint.transform.position, origin);
            float backDistance = Vector3.Distance(BackWaypoint.transform.position, origin);

            if (forwardDistance < backDistance) return FowardWaypoint;
            else return BackWaypoint;
        }

        public bool ForwardIsClosest(Vector3 origin)
        {
            float forwardDistance = Vector3.Distance(FowardWaypoint.transform.position, origin);
            float backDistance = Vector3.Distance(BackWaypoint.transform.position, origin);

            if (forwardDistance < backDistance) return true;
            else return false;
        }
    }

    public void SetNavSystem(WaypointPair pair)
    {
        waypointPair = pair;
        // work out the closest
        forward = waypointPair.ForwardIsClosest(transform.position);
        // use the movement comenonent to go to waypoint
        SetNextWaypoint();
    }

    private void SetNextWaypoint()
    {
        if (forward)
        {
            ship.ShipMovement.SetTargetWaypoint(waypointPair.FowardWaypoint);
        }
        else
        {
            ship.ShipMovement.SetTargetWaypoint(waypointPair.BackWaypoint);
        }
        ship.ShipMovement.FaceWaypoint();
    }

    private void OnArriveToWaypoint()
    {
        forward = !forward;
        SetNextWaypoint();
        //Debug.Log(name + " Recieved on arrive event");

    }
}
