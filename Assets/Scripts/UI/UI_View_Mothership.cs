using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_View_Mothership : MonoBehaviour
{
    [SerializeField] UI_TurretInfoList starboardTurretList;
    [SerializeField] UI_TurretInfoList portTurretList;

    private void OnEnable()
    {
        starboardTurretList.RedrawList();
        portTurretList.RedrawList();
    }

    private void OnDisable()
    {
        starboardTurretList.ClearList();
        portTurretList.ClearList();
    }
}
