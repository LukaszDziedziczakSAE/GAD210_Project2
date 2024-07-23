using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipPower : MonoBehaviour
{
    [field: SerializeField] public float CurrentPower {  get; private set; }
    [field: SerializeField] public float MaxPower {  get; private set; }

    public float Percentage => CurrentPower / MaxPower;

    private void Start()
    {
        CurrentPower = MaxPower;
        UI.UpdatePowerIndicator();
    }
}
