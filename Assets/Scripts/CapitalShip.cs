using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitalShip : MonoBehaviour
{
    [field: SerializeField] public Waypoint ForwardStarboardWaypoint {  get; private set; }
    [field: SerializeField] public Waypoint ForwardPortWaypoint { get; private set; }
    [field: SerializeField] public Waypoint AftStarboardWaypoint { get; private set; }
    [field: SerializeField] public Waypoint AftPortWaypoint { get; private set; }

}
