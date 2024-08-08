using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade_Base : MonoBehaviour
{
    [field: SerializeField] public string UpgradeName { get; protected set; }
    [field: SerializeField] public int Level { get; protected set; } = 1;
    [field: SerializeField] public float[] Values { get; protected set; }
    [field: SerializeField] public int[] Costs { get; protected set; }

    public float CurrentValue => Values[Level - 1];
    public int CurrentCost => Costs[Level - 1];

    protected void Start()
    {
        if (Values.Length == 0)
        {
            Debug.LogError(name + " Values at length 0");
            return;
        }
        if (Costs.Length == 0)
        {
            Debug.LogError(name + " Costs at length 0");
            return;
        }

        ApplyValues();
    }

    public void ApplyUpgrade()
    {
        if (Level < Values.Length && CanAfford)
        {
            Level++;
            ConsumeCost();
            ApplyValues();
            UI.Sound.PlayTurretUpgraded();
        }
        else UI.Sound.PlayUnable();
    }

    public abstract void ApplyValues();

    public bool CanAfford
    {
        get
        {
            return Game.Mothership.Resources.CanAfford(CurrentCost);
        }
    }

    public void ConsumeCost()
    {
        Game.Mothership.Resources.RemoveResources(CurrentCost);
    }
}
