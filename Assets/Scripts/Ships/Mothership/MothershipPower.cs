using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipPower : MonoBehaviour
{
    [field: SerializeField] public float CurrentPower {  get; private set; }
    [field: SerializeField] public float MaxPower {  get; private set; }
    [field: SerializeField] public float RechargeRate { get; private set; }

    public float Percentage => CurrentPower / MaxPower;

    private void Start()
    {
        CurrentPower = MaxPower;
        UI.UpdatePowerIndicator();
    }

    private void Update()
    {
        if (CurrentPower < MaxPower)
        {
            RestorePower(RechargeRate * Time.deltaTime);
        }
    }

    public void UsePower(float amount)
    {
        CurrentPower = Mathf.Clamp(CurrentPower - amount, 0, MaxPower);
        UI.UpdatePowerIndicator();
    }

    public void RestorePower(float amount)
    {
        CurrentPower = Mathf.Clamp(CurrentPower + amount, 0, MaxPower);
        UI.UpdatePowerIndicator();
    }

    public bool CanAfford(float cost, out int amount)
    {
        if (CurrentPower - cost < 0)
        {
            amount = 0;
            return false;
        }

        amount = Mathf.FloorToInt(CurrentPower / cost);
        return true;
    }
}
