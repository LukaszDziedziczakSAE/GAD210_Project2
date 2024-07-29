using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPower : MonoBehaviour
{
    [field: SerializeField] public int MaxCapacity { get; private set; }
    [field: SerializeField] public int CurrentPower { get; private set; }
    [field: SerializeField] public int ShotCost { get; private set; }

    private void Start()
    {
        Resupply();
    }

    public bool CanFire => CurrentPower - ShotCost >= 0;

    public void ConsumeShotCost()
    {
        CurrentPower -= ShotCost;
        Debug.Log("Remining power = " + CurrentPower);
    }

    public void Resupply()
    {
        CurrentPower = MaxCapacity;
    }

    public float Percentage => (float)CurrentPower / (float)MaxCapacity;

    public float GetCurretPower()
    {
        return CurrentPower;
    }
}
