using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float CurrentHealth { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; }
    [SerializeField] EnemyExplosion deathExplosion;

    public event Action OnDeath;

    private void Start()
    {
        CurrentHealth = MaxHealth;

    }
    public void ApplyDamage(float damage)
    {
        //Debug.Log(name + " took " + damage + " damage");
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);

        if(CurrentHealth == 0)
        {
            //Debug.Log(name + " destroyed");
            if (deathExplosion != null) Instantiate(deathExplosion, transform.position, transform.rotation);
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }

    public void RestoreHealth(float RestoreAmount)
    {
        CurrentHealth += RestoreAmount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }
    
}
