using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_FireRate : Upgrade_Base
{
    Turret turret;

    private void Awake()
    {
        turret = GetComponent<Turret>();
    }

    public override void ApplyValues()
    {
        if (turret != null) turret.ProjectileLauncher.SetFireRate(CurrentValue);
    }
}
