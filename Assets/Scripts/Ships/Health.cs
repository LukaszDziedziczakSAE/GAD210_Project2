using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float CurrentHealth { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; } = 100f;

    public event Action OnDeath;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
        
        if(CurrentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void RestoreHealth(float restoreAmount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + restoreAmount, 0, MaxHealth);
    }

    public float Percentage => CurrentHealth / MaxHealth;

    public float GetHealthPercentage()
    {
        return CurrentHealth / MaxHealth;
    }
}
