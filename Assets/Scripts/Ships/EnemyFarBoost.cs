using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFarBoost : MonoBehaviour
{
    ShipMovement movement;
    [SerializeField] float distance = 250f;

    float distanceToTransport => Vector3.Distance(Game.TransportShip.transform.position, transform.position);

    private void Awake()
    {
        movement = GetComponent<ShipMovement>();
    }

    private void Update()
    {
        movement.BoostedSpeed = distanceToTransport > distance;
    }
}
