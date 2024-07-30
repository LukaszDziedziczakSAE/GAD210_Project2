using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Range : Upgrade_Base
{
    Turret turret;

    private void Awake()
    {
        turret = GetComponent<Turret>();
        
    }

    public override void ApplyValues()
    {
        if (turret == null) return;

        turret.Targeting.SetRange(CurrentValue);
    }
}
