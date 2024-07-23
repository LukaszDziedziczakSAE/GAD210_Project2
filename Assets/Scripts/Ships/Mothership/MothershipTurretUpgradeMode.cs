using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipTurretUpgradeMode : MonoBehaviour
{
    Turret turret;

    public void EnterTurretUpgradeMode(Turret turret)
    {
        this.turret = turret;
        Game.CameraController.SwitchToTurretCamera(turret.Camera);
        UI.SwitchToTurretView();
    }

    public void ExitTurretUpgradeMode()
    {
        Game.CameraController.SwitchToMothershipCamera();
        turret = null;
        UI.SwitchToMothershipView();
    }
}
