using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_View_Tactical : MonoBehaviour
{
    [SerializeField] UI_TurretList starboardTurretList;
    [SerializeField] UI_TurretList portTurretList;

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
