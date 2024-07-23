using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitalShip : MonoBehaviour
{
    [field: SerializeField] public EnemyWaypoint ForwardStarboardWaypoint {  get; private set; }
    [field: SerializeField] public EnemyWaypoint ForwardPortWaypoint { get; private set; }
    [field: SerializeField] public EnemyWaypoint AftStarboardWaypoint { get; private set; }
    [field: SerializeField] public EnemyWaypoint AftPortWaypoint { get; private set; }

}
