using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float CurrentHealth { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; }

    public event Action OnDeath;

    private void Start()
    {
        CurrentHealth = MaxHealth;

    }
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        if(CurrentHealth == 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void RestoreHealth(float RestoreAmount)
    {
        CurrentHealth += RestoreAmount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }



    
}
