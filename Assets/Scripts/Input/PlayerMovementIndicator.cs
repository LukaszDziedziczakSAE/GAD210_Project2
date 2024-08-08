using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementIndicator : Waypoint
{ 
    [SerializeField] ParticleSystem indicator;
    [SerializeField] LineRenderer lineRenderer;

    private void Start()
    {
        Game.Mothership.ShipMovement.SetTargetWaypoint(this);
        Game.Mothership.ShipMovement.OnArrived += OnArrival;
        
    }

    private void OnDisable()
    {
        Game.Mothership.ShipMovement.OnArrived -= OnArrival;
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, Game.Mothership.transform.position);

        if (!indicator.isPlaying && Game.Input.LeftClickDown && !UI.MouseOverUI)
        {
            indicator.Play();
        }
    }

    private void OnArrival()
    {
        Destroy(gameObject);
    }
}
