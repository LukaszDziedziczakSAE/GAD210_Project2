using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HealthIndicator : MonoBehaviour
{
    [SerializeField] RectTransform levelIndicator;
    [SerializeField] bool mothershipHealthIndicator;
    [SerializeField] bool transportshipHealthIndicator;

    public void UpdateHealthLevel()
    {
        if (mothershipHealthIndicator) levelIndicator.localScale = new Vector3(Game.Mothership.Health.Percentage, 1, 1);

        if (transportshipHealthIndicator) levelIndicator.localScale = new Vector3(Game.TransportShip.Health.Percentage, 1, 1);
    }
}
