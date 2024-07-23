using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] Vector3 targetLocation;
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] float targetProximity = 0.5f;

    Waypoint targetWaypoint;

    public event Action OnArrived;



    private void Update()
    {
        if (targetWaypoint == null && targetLocation == Vector3.zero) return;
        
        Vector3 targetDirection;
        if (targetWaypoint != null)
        {
            if(Vector3.Distance(transform.position, targetWaypoint.transform.position)< targetProximity)
            {
                targetWaypoint = null;
                OnArrived?.Invoke();
                OnArrived = null;
                return;
                
            }
            targetDirection =   targetWaypoint.transform.position - transform.position;
        }
        else
        {
            if (Vector3.Distance(transform.position, targetLocation) < targetProximity)
            {
                ClearTargetPosition();
                OnArrived?.Invoke();
                OnArrived = null;
                return;

            }
            targetDirection = targetLocation - transform.position;
        }
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        
    }
    
    public void SetTargetWaypoint(Waypoint waypoint)
    {
        targetWaypoint = waypoint;
    }

    public void SetTargetPosition(Vector3 target)
    {
        targetLocation = target;
    }

    public void ClearTargetPosition()
    {
        targetLocation = Vector3.zero;
    }
  
}
