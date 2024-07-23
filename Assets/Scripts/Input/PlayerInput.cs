using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Mothership mothership;
    [SerializeField] LayerMask inputLayer;
    [SerializeField] LayerMask shipLayer;
    [SerializeField] bool drawDebugLine;
    [SerializeField] float raycastDistance = 200;

    private void Awake()
    {
        mothership = GetComponent<Mothership>();
    }

    private void Start()
    {
        Game.Input.LeftClickPress += OnLeftClickPress;
        Game.Input.LeftClickRelease += OnLeftClickRelease;
    }

    private void Update()
    {
        if (!mothership.BuildMode.InBuildMode && Game.Input.LeftClickDown)
        {
            mothership.ShipMovement.SetTargetPosition(inputPlanePos);
        }
    }

    private void OnLeftClickPress()
    {
        if (Game.CameraController.InTurretCameraMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Game.Input.MousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, shipLayer))
            {
                if (hit.collider.tag == "Mothership" || hit.collider.tag == "InputPlane")
                {
                    mothership.TurretUpgradeMode.ExitTurretUpgradeMode();
                }
            }
        }

        else if (mothership.BuildMode.InBuildMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Game.Input.MousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, shipLayer))
            {
                if (hit.collider.TryGetComponent<Turret>(out Turret turret))
                {
                    if (turret.State == Turret.EState.Buildable && turret.CanAfford) turret.Build();
                    else if (turret.State == Turret.EState.Built) mothership.TurretUpgradeMode.EnterTurretUpgradeMode(turret);
                }
                
                else if (hit.collider.tag == "InputPlane") mothership.BuildMode.ExitBuildMode();
            }

            else Debug.LogWarning("Build Mode Raycast Miss");
        }

        else if (!mothership.BuildMode.InBuildMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Game.Input.MousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, shipLayer))
            {
                if (hit.collider.tag == "Mothership") mothership.BuildMode.EnterBuildMode();
                else mothership.ShipMovement.SetTargetPosition(hit.point);
            }
        }
    }

    private void OnLeftClickRelease()
    {
        mothership.ShipMovement.ClearTargetPosition();
    }

    private Vector3 inputPlanePos
    {
        get
        {
            Ray ray = Camera.main.ScreenPointToRay(Game.Input.MousePosition);
            if (drawDebugLine) Debug.DrawRay(ray.origin, ray.origin + (ray.direction * raycastDistance), Color.red);
            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, inputLayer))
            {
                return hit.point;
            }
            Debug.LogError("Raycast Miss");
            return Vector3.zero;
        }
    }
}
