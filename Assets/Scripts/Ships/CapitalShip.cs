using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitalShip : Ship
{
    [field: SerializeField, Header("Capital Ship Referances")] public Waypoint ForwardStarboardWaypoint {  get; private set; }
    [field: SerializeField] public Waypoint ForwardPortWaypoint { get; private set; }
    [field: SerializeField] public Waypoint AftStarboardWaypoint { get; private set; }
    [field: SerializeField] public Waypoint AftPortWaypoint { get; private set; }

    public EnemyAI.WaypointPair StarboardPair
    {
        get
        {
            EnemyAI.WaypointPair pair = new EnemyAI.WaypointPair();
            pair.FowardWaypoint = ForwardStarboardWaypoint;
            pair.BackWaypoint = AftStarboardWaypoint;
            return pair;
        }
    }

    public EnemyAI.WaypointPair PortPair
    {
        get
        {
            EnemyAI.WaypointPair pair = new EnemyAI.WaypointPair();
            pair.FowardWaypoint = ForwardPortWaypoint;
            pair.BackWaypoint = AftPortWaypoint;
            return pair;
        }
    }

    public EnemyAI.WaypointPair RandomPair
    {
        get
        {
            int random = Random.Range(0, 2);
            if (random == 0) return StarboardPair;
            else return PortPair;
        }
    }
}
