using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportShipStartPosition : MonoBehaviour
{
    CapitalShip ship;
    [SerializeField] Vector3[] startingPositions;

    private Vector3 startingPosition => startingPositions[Random.Range(0, startingPositions.Length)];

    private void Awake()
    {
        ship = GetComponent<CapitalShip>();
    }


    public void SetStartPosition(Vector3 destinationPosition)
    {
        transform.position = startingPosition;
        ship.ShipMovement.SetStartingDistance(transform.position);
        transform.LookAt(destinationPosition);
    }
}
