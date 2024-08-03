using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipSpeedBoost : MonoBehaviour
{
    Mothership mothership;

    [SerializeField] float boostLength; // in seconds
    [SerializeField] int boostCost = 10;

    float boostStartTime;
    public float Progress => (Time.time - boostStartTime) / boostLength;

    private void Awake()
    {
        mothership = GetComponent<Mothership>();
    }

    private void Update()
    {
        if (mothership.ShipMovement.BoostedSpeed)
        {
            if (Progress > 1)
            {
                mothership.ShipMovement.BoostedSpeed = false;
                UI.TacticalView.BoostButton.BoostComplete();
            }
        }
    }

    public void ActivateBoost()
    {
        print("Boost activated");
        mothership.Power.UsePower(boostCost);
        boostStartTime = Time.time;
        mothership.ShipMovement.BoostedSpeed = true;
    }

    public bool CanAfford
    {
        get
        {
            return mothership.Power.CanAfford(boostCost, out int amount);
        }
    }
}
