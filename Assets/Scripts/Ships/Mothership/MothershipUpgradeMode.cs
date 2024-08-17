using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipUpgradeMode : MonoBehaviour
{
    public Turret SelectedTurret { get; private set; }
    public MothershipModule SelectedModule { get; private set; }
    public bool InUpgradeMode { get; private set; }

    public void EnterUpgradeMode(Turret turret)
    {
        this.SelectedTurret = turret;
        Game.CameraController.SwitchToTurretCamera(turret.Camera);
        UI.SwitchToTurretView();
        InUpgradeMode = true;
        Game.Mothership.BuildMode.EnterUpgradeMode();
    }

    public void EnterUpgradeMode(MothershipModule mothershipUpgrade)
    {
        this.SelectedModule = mothershipUpgrade;
        Game.CameraController.SwitchToTurretCamera(SelectedModule.Camera);
        UI.SwitchToTurretView();
        InUpgradeMode = true;
        Game.Mothership.BuildMode.EnterUpgradeMode();
    }

    public void ExitTurretUpgradeMode()
    {
        Game.CameraController.SwitchToMothershipCamera();
        SelectedTurret = null;
        SelectedModule = null;
        UI.SwitchToMothershipView();
        InUpgradeMode = false;
    }

    public void ExitToTacticalMode()
    {
        Game.CameraController.SwitchToPlayCamera();
        SelectedTurret = null;
        SelectedModule = null;
        UI.SwitchToPlayView();
        InUpgradeMode = false;
    }
}
