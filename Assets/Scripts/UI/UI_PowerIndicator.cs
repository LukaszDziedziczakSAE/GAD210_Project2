using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PowerIndicator : MonoBehaviour
{
    [SerializeField] RectTransform powerLevelIndicator;

    public void UpdatePowerLevel()
    {
        powerLevelIndicator.localScale = new Vector3(Game.Mothership.Power.Percentage, 1, 1);
    }
}
