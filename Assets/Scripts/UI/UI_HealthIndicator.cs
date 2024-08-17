using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthIndicator : MonoBehaviour
{
    [SerializeField] RectTransform levelIndicator;
    [SerializeField] Image circleIndicator;
    [SerializeField] bool mothershipHealthIndicator;
    [SerializeField] bool transportshipHealthIndicator;

    public void UpdateHealthLevel()
    {
        if (mothershipHealthIndicator)
        {
            if (levelIndicator) levelIndicator.localScale = new Vector3(Game.Mothership.Health.Percentage, 1, 1);

            if (circleIndicator) circleIndicator.fillAmount = Game.Mothership.Health.Percentage;
        }

        if (transportshipHealthIndicator)
        {
            if (levelIndicator) levelIndicator.localScale = new Vector3(Game.TransportShip.Health.Percentage, 1, 1);

            if (circleIndicator) circleIndicator.fillAmount = Game.TransportShip.Health.Percentage;
        }
    }
}
