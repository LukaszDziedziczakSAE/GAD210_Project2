using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    Turret turret;
    [SerializeField] List<Ship> inRange = new List<Ship>();
    [SerializeField] float timeOffSet = 0.05f;
    [SerializeField] SphereCollider sphereCollider;

    private float projectilSpeed => turret.ProjectileLauncher.ProjectileSpeed;
    public bool HasTargetInRange => inRange.Count > 0;

    private void Awake()
    {
        turret = GetComponentInParent<Turret>();
    }

    private void Update()
    {
        if (turret.State != Turret.EState.Built) return;

        if (inRange.Count > 0)
        {
            foreach (Ship enemyShip in inRange.ToArray())
            {
                if (enemyShip == null) inRange.Remove(enemyShip);
            }

            if (turret.ShowDebugs) Debug.Log(turret.name + ": " + HeadingToward(inRange[0].transform.position));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Turret" || other.tag == "TurretTargetting" || other.tag == "InputPlane") return;
        if (turret.ShowDebugs) Debug.Log(turret.name + " trigger enter " + other.name);


        if (turret.State != Turret.EState.Built)
        {
            //if (turret.ShowDebugs) Debug.LogWarning(name + " is in " + turret.State + " state");
            return;
        }

        if (other.TryGetComponent<Ship>(out Ship ship))
        {
            EnemyShip enemyShip = ship.GetComponent<EnemyShip>();
            if (turret.IsEnemy) 
            {
                if (enemyShip == null)
                {
                    inRange.Add(ship);
                    if (turret.ShowDebugs) Debug.Log(turret.name + " has " + ship.name + " (ship) in range");
                }
                
            }
            else if (!turret.IsEnemy)
            {
                if (enemyShip != null)
                {
                    inRange.Add(ship);
                    if (turret.ShowDebugs) Debug.Log(turret.name + " has " + ship.name + " (ship) in range");
                }
            }

            
        }
        else
        {
            if (turret.ShowDebugs) Debug.LogWarning(turret.name + " has " + other.name + " in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (turret.State != Turret.EState.Built) return;

        if (other.TryGetComponent<Ship>(out Ship ship))
        {
            inRange.Remove(ship);
        }
    }

    public Ship Target
    {
        get
        {
            Ship closestShip = null;
            float closestDistance = Mathf.Infinity;

            foreach (Ship ship in inRange)
            {
                if (ship == null) continue;

                float distance = Vector3.Distance(ship.transform.position, transform.position);
                if (distance < closestDistance)
                {
                    float heading = HeadingToward(ship.transform.position);
                    if (turret.Type != Turret.EType.Omnidirectional /*&& 
                        heading > -turret.FiringAngle && heading < turret.FiringAngle*/)
                    {
                        closestDistance = distance;
                        closestShip = ship;
                    }
                    else if (turret.Type == Turret.EType.Omnidirectional)
                    {
                        closestDistance = distance;
                        closestShip = ship;
                    }
                    
                }
            }

            return closestShip;
        }
    }

    public Vector3 TargetPosition
    {
        get
        {
            if (Target == null) return Vector3.zero;
            float timeToShip = Vector3.Distance(transform.position, Target.transform.position) / projectilSpeed;
            timeToShip -= timeOffSet;
            //float timeToTarget = Vector3.Distance(transform.position, Target.ShipMovement.PositionInSeconds(timeToShip));
            return Target.ShipMovement.PositionInSeconds(timeToShip);
        }
    }

    public bool HasTargets => Target != null;

    public float HeadingTowardTarget
    {
        get
        {
            return HeadingToward(TargetPosition);
        }
    }

    public float HeadingToward(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        float angle = (Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg) - 90;
        angle *= -1;
        if (turret.Type == Turret.EType.Starboard) angle -= 180;
        return angle - transform.position.y;
    }

    public void SetRange(float value)
    {
        if (sphereCollider != null)
        {
            sphereCollider.radius = value;
        }
    }
}
