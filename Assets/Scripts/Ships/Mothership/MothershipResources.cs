using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipResources : MonoBehaviour
{
    [SerializeField] int startingResources;
    [field: SerializeField] public int CurrentResources {  get; private set; }

    private void Start()
    {
        CurrentResources = startingResources;
        UI.UpdateResourceIndicator();
    }

    public bool CanAfford(int cost)
    {
        return CurrentResources - cost >= 0;
    }

    public void RemoveResources(int amount)
    {
        CurrentResources = Mathf.Clamp(CurrentResources - amount, 0, int.MaxValue);
        UI.UpdateResourceIndicator();
    }

    public void AddResources(int amount)
    {
        CurrentResources += amount;
        UI.UpdateResourceIndicator();
    }
}
