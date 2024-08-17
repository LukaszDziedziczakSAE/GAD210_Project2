using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float CurrentHealth { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; }
    [SerializeField] EnemyExplosion deathExplosion;

    public static event Action<Ship> OnDeath;
    public event Action OnThisDeath;
    private Ship ship;

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;

        if (ship.Type == Ship.EType.Mothership) UI.UpdateMothershipHealthIndicator();
        if (ship.Type == Ship.EType.Transport) UI.UpdateTransportShipHealthIndicator();
    }

    public void ApplyDamage(float damage)
    {
        //Debug.Log(name + " took " + damage + " damage");
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);

        if (ship.Type == Ship.EType.Mothership) UI.UpdateMothershipHealthIndicator();
        if (ship.Type == Ship.EType.Transport) UI.UpdateTransportShipHealthIndicator();

        if (CurrentHealth == 0)
        {
            //Debug.Log(name + " destroyed");
            if (deathExplosion != null) Instantiate(deathExplosion, transform.position, transform.rotation);
            OnDeath?.Invoke(ship);
            OnThisDeath?.Invoke();

            if (ship.Type == Ship.EType.Transport)
            {
                MatchState matchState = Game.SpawnMatchState();
                matchState.Result = MatchState.EMatchResult.TransportDestroyed;
                Game.ReturnToStartScreen();
            }
            else if (ship.Type == Ship.EType.Transport)
            {
                MatchState matchState = Game.SpawnMatchState();
                matchState.Result = MatchState.EMatchResult.MothershipDestroyed;
                Game.ReturnToStartScreen();
            }
            else Destroy(gameObject);
        }
    }

    public void RestoreHealth(float RestoreAmount)
    {
        CurrentHealth += RestoreAmount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }

    public float Percentage => CurrentHealth / MaxHealth;

    public void SetMaxHealth(float maxHealth)
    {
        this.MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }
    
}
