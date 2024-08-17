using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipBuildMode : MonoBehaviour
{
    Mothership mothership;
    [field: SerializeField] public bool InBuildMode {  get; private set; }
    [field: SerializeField] public int TurretCost { get; private set; }

    private void Awake()
    {
        mothership = GetComponent<Mothership>();
    }

    public void EnterBuildMode()
    {
        Game.CameraController.SwitchToMothershipCamera();
        UI.SwitchToMothershipView();
        foreach (Turret turret in mothership.Turrets)
        {
            if (turret.State == Turret.EState.Unbuilt) turret.SetBuildableState();
        }

        InBuildMode = true;
    }

    public void ExitBuildMode()
    {
        Game.CameraController.SwitchToPlayCamera();
        UI.SwitchToPlayView();
        foreach (Turret turret in mothership.Turrets)
        {
            if (turret.State == Turret.EState.Buildable) turret.SetUnbuiltState();
        }

        InBuildMode = false;
    }

    public void EnterUpgradeMode()
    {
        InBuildMode = false;
    }
}
