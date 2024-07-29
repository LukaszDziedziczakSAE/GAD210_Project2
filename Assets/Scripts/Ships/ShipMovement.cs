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



    private void Update()
    {
        if (targetWaypoint == null && targetLocation == Vector3.zero) return;
        
        //Vector3 targetDirection;
        /*if (targetWaypoint != null)
        {
            if (Vector3.Distance(transform.position, targetWaypoint.transform.position) < targetProximity)
            {
                targetWaypoint = null;
                OnArrived?.Invoke();
                Debug.Log(name + " Reached waypoint");

                return;

            }
            targetDirection = targetWaypoint.transform.position - transform.position;
        }
        else
        {
            if (Vector3.Distance(transform.position, targetLocation) < targetProximity)
            {
                ClearTargetPosition();
                OnArrived?.Invoke();

                return;

            }
            targetDirection = targetLocation - transform.position;
        }*/
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
    }

    public void ClearTargetWaypoint()
    {
        targetWaypoint = null;
    }

    public void SetTargetPosition(Vector3 target)
    {
        targetLocation = target;
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
            print("targetDirection " + direction + ", ownPosition " + transform.position);
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
}
