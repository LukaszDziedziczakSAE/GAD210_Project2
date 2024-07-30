using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Firepower : Upgrade_Base
{
    Turret turret;
    private void Awake()
    {
        turret = GetComponent<Turret>();
    }

    public override void ApplyValues()
    {
        turret.SetFirepower(CurrentValue);
    }
}
