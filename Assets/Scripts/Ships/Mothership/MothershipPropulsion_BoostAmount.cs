using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipPropulsion_BoostAmount : Upgrade_Base
{
    Mothership mothership;

    private void Awake()
    {
        mothership = GetComponentInParent<Mothership>();
    }


    public override void ApplyValues()
    {
        mothership.ShipMovement.SetBoostedSpeed(CurrentValue);
    }
}
