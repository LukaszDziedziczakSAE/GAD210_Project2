using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceOnDeath : MonoBehaviour
{
    [field: SerializeField] public int RewardOnKill {  get; private set; }
    [SerializeField] Health health;

    private void OnEnable()
    {
        if (health == null) health = GetComponent<Health>();
        health.OnThisDeath += GiveReward;
    }

    private void OnDisable()
    {
        health.OnThisDeath -= GiveReward;
    }


    public void GiveReward()
    {
        Game.Mothership.Resources.AddResources(RewardOnKill);
    }

    public void SetReward(int reward)
    {
        RewardOnKill = reward;
    }
}
