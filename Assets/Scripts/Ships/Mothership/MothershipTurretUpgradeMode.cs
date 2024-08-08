using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipTurretUpgradeMode : MonoBehaviour
{
    public Turret SelectedTurret { get; private set; }

    public void EnterTurretUpgradeMode(Turret turret)
    {
        this.SelectedTurret = turret;
        Game.CameraController.SwitchToTurretCamera(turret.Camera);
        UI.SwitchToTurretView();
    }

    public void ExitTurretUpgradeMode()
    {
        Game.CameraController.SwitchToMothershipCamera();
        SelectedTurret = null;
        UI.SwitchToMothershipView();
    }

    public void ExitToTacticalMode()
    {
        Game.CameraController.SwitchToPlayCamera();
        SelectedTurret = null;
        UI.SwitchToPlayView();
    }
}
