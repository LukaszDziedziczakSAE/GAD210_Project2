using Cinemachine.Utility;
using System;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] float targetProximity = 0.5f;
    [SerializeField] Waypoint targetWaypoint;
    [SerializeField] Vector3 targetLocation;

    public event Action OnArrived;
    public bool IsMoving => targetLocation != Vector3.zero || targetWaypoint != null;
    private float startDistance;

    private void Start()
    {
        if (targetWaypoint != null)
        {
            startDistance = Vector3.Distance(transform.position, targetWaypoint.transform.position);
        }

    }

    private void Update()
    {
        if (targetWaypoint == null && targetLocation == Vector3.zero) return;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        if (reachedTargetPosition)
        {
            ClearTargetWaypoint();
            ClearTargetPosition();
            OnArrived?.Invoke();
        }
    }
    
    public void SetTargetWaypoint(Waypoint waypoint)
    {
        targetWaypoint = waypoint;
        startDistance = Vector3.Distance(transform.position, waypoint.transform.position);
    }

    public void ClearTargetWaypoint()
    {
        targetWaypoint = null;
    }

    public void SetTargetPosition(Vector3 target)
    {
        targetLocation = target;
        startDistance = Vector3.Distance(transform.position, target);
    }

    public void ClearTargetPosition()
    {
        targetLocation = Vector3.zero;
    }

    private Vector3 targetDirection
    {
        get
        {
            Vector3 direction = targetPosition - transform.position;
            return direction;

        }
    }

    private Vector3 targetPosition
    {
        get
        {
            Vector3 targetPos;
            if (targetWaypoint != null)
            {
                targetPos = targetWaypoint.transform.position;
            }
            else
            {
                targetPos = targetLocation;
            }
            targetPos.y = transform.position.y;
            return targetPos;
        }
    }

    private bool reachedTargetPosition
    {
        get
        {
            return Vector3.Distance(transform.position, targetPosition) <= targetProximity;
        }
    }

    public Vector3 PositionInSeconds(float seconds)
    {
        if (!IsMoving) return transform.position;
        return transform.position + (transform.forward * moveSpeed * seconds);
    }

    public float ProgressToWaypoint
    {
        get
        {
            float currentDistance = Vector3.Distance(transform.position, targetWaypoint.transform.position);
            return 1 - (currentDistance / startDistance);
        }
    }
}
