using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_View_Upgrade : MonoBehaviour
{
    [field: SerializeField] public UI_UpgradesList UpgradesList { get; private set; }

    public void OnReturnToMothershiplViewButtonPress()
    {
        Game.Mothership.UpgradeMode.ExitTurretUpgradeMode();
    }

    public void OnReturnToTacticalViewButtonPress()
    {
        Game.Mothership.UpgradeMode.ExitToTacticalMode();
    }
}
    