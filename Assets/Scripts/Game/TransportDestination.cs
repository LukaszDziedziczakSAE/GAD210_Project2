using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class TransportDestination : MonoBehaviour
{
    [SerializeField] Waypoint endPoint;
    [SerializeField] float gameLength; // in minutes

    float distance => transportShip.ShipMovement.Speed * (gameLength * 60);

    CapitalShip transportShip => Game.TransportShip;

    private void Start()
    {
        endPoint.transform.position = PositionOnCircle(transportShip.transform.position, randomAngle, distance);

        //print(Vector3.Distance(transportShip.transform.position, endPoint.transform.position) / transportShip.ShipMovement.Speed);

        transportShip.GetComponent<TransportShipStartPosition>().SetStartPosition(endPoint.transform.position);
    }

    private Vector3 PositionOnCircle(Vector3 center, float angle, float radius)
    {
        float x = Mathf.Cos(angle) * radius + center.x;
        float y = center.y;
        float z = Mathf.Sin(angle) * radius + center.z;
        return new Vector3(x, y, z);
    }

    private float randomAngle => Random.Range(0, 360);
}
