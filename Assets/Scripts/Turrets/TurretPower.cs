using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPower : MonoBehaviour
{
    Turret turret;
    [field: SerializeField] public int MaxCapacity { get; private set; }
    [field: SerializeField] public int CurrentPower { get; private set; }
    [field: SerializeField] public int ShotCost { get; private set; }

    private void Awake()
    {
        turret = GetComponent<Turret>();
    }

    private void Start()
    {
        CurrentPower = MaxCapacity;
    }

    public bool CanFire => CurrentPower - ShotCost >= 0;

    public void ConsumeShotCost()
    {
        CurrentPower -= ShotCost;
        if (turret.ShowDebugs) Debug.Log("Remining power = " + CurrentPower);
    }

    public void Resupply(int amount)
    {
        CurrentPower += amount;
    }

    public float Percentage => (float)CurrentPower / (float)MaxCapacity;

    public float GetCurretPower()
    {
        return CurrentPower;
    }

    public int PowerNeeded => MaxCapacity - CurrentPower;

    public void SetMaxCapacity(int newCap)
    {
        MaxCapacity = newCap;
    }
}
