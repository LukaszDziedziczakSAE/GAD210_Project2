using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipPowerCapacityUpgrade : Upgrade_Base
{
    Mothership mothership;

    private void Awake()
    {
        mothership = GetComponentInParent<Mothership>();
    }

    public override void ApplyValues()
    {
        mothership.Power.SetMax(CurrentValue);
    }
}
