using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Capacity : Upgrade_Base
{
    [SerializeField] Turret turret;

    private void Awake()
    {
        turret = GetComponent<Turret>();
    }

    public override void ApplyValues()
    {
        if (turret != null && turret.Power != null) turret.Power.SetMaxCapacity((int)CurrentValue);
    }
}
