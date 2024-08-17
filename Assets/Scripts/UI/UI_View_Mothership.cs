using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_View_Mothership : MonoBehaviour
{
    [SerializeField] UI_TurretInfoList starboardTurretList;
    [SerializeField] UI_TurretInfoList portTurretList;
    [SerializeField] UI_MothershipModuleList mothershipModuleList;

    private void OnEnable()
    {
        starboardTurretList.RedrawList();
        portTurretList.RedrawList();
        mothershipModuleList.RedrawList();
    }

    private void OnDisable()
    {
        starboardTurretList.ClearList();
        portTurretList.ClearList();
        mothershipModuleList.ClearList();
    }

    public void OnReturnToTacticalViewButtonPress()
    {
        Game.Mothership.BuildMode.ExitBuildMode();
    }
}
