using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ShipMovement movement;

    private void Start()
    {
        movement.SetTargetWaypoint(Game.TransportShip.AftPortWaypoint);
    }

}
