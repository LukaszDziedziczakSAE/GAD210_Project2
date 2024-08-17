using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PowerIndicator : MonoBehaviour
{
    [SerializeField] RectTransform powerLevelIndicator;
    [SerializeField] Image circleIndicator;

    public void UpdatePowerLevel()
    {
        if (powerLevelIndicator) powerLevelIndicator.localScale = new Vector3(Game.Mothership.Power.Percentage, 1, 1);

        if (circleIndicator) circleIndicator.fillAmount = Game.Mothership.Power.Percentage;
    }
}
