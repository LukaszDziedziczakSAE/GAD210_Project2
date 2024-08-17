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
    [SerializeField] PlayerMovementIndicator playerMovementIndicatorPrefab;
    PlayerMovementIndicator playerMovementIndicator;

    private void Awake()
    {
        mothership = GetComponent<Mothership>();
    }

    private void Start()
    {
        Game.Input.LeftClickPress += OnLeftClickPress;
        Game.Input.LeftClickRelease += OnLeftClickRelease;
        Game.Input.PauseMenuPress += OnPauseMenuPress;
    }

    private void OnDisable()
    {
        Game.Input.LeftClickPress -= OnLeftClickPress;
        Game.Input.LeftClickRelease -= OnLeftClickRelease;
        Game.Input.PauseMenuPress -= OnPauseMenuPress;
    }

    private void Update()
    {
        /*if (!mothership.BuildMode.InBuildMode && Game.Input.LeftClickDown && !UI.MouseOverUI)
        {
            mothership.ShipMovement.SetTargetPosition(inputPlanePos);
        }*/

        if (!mothership.BuildMode.InBuildMode && Game.Input.LeftClickDown && !UI.MouseOverUI)
        {
            SetPlayerMovementIndicatorPosition(inputPlanePos);
        }
    }

    private void OnLeftClickPress()
    {
        if (UI.MouseOverUI) return;

        //Debug.Log("InUpgradeMode = " + mothership.UpgradeMode.InUpgradeMode + ", InBuildMode = " + mothership.BuildMode.InBuildMode + ", InTacticalMode = " + mothership.InTacticalMode);

        if (mothership.UpgradeMode.InUpgradeMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Game.Input.MousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, shipLayer))
            {
                if (hit.collider.tag == "Mothership" || hit.collider.tag == "InputPlane")
                {
                    mothership.UpgradeMode.ExitTurretUpgradeMode();
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
                    if (turret.State == Turret.EState.Buildable) turret.Build();
                    else if (turret.State == Turret.EState.Built) mothership.UpgradeMode.EnterUpgradeMode(turret);
                }
                
                else if (hit.collider.tag == "InputPlane") mothership.BuildMode.ExitBuildMode();
            }

            else Debug.LogWarning("Build Mode Raycast Miss");
        }

        else if (mothership.InTacticalMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Game.Input.MousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, shipLayer))
            {
                if (hit.collider.tag == "Mothership") mothership.BuildMode.EnterBuildMode();
                else
                {
                    //mothership.ShipMovement.SetTargetPosition(hit.point);
                    SpawnPlayerMovementIndicator(hit.point);
                }
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

    private void OnPauseMenuPress()
    {
        Game.ReturnToStartScreen();
    }

    private void SpawnPlayerMovementIndicator(Vector3 position)
    {
        if (playerMovementIndicator != null) Destroy(playerMovementIndicator.gameObject);

        Vector3 spawnPosition = new Vector3(position.x, 0, position.z);

        playerMovementIndicator = Instantiate(playerMovementIndicatorPrefab, spawnPosition, Quaternion.identity);
    }

    private void SetPlayerMovementIndicatorPosition(Vector3 position)
    {
        if (playerMovementIndicator != null)
        {
            Vector3 zeroedPosition = new Vector3(position.x, 0, position.z);
            playerMovementIndicator.transform.position = zeroedPosition;
        }
    }
}
