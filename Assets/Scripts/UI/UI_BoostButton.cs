using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BoostButton : MonoBehaviour
{
    [SerializeField] Button boostButton;
    [SerializeField] Image progressIndicator;

    private void OnEnable()
    {
        boostButton.onClick.AddListener(OnButtonPress);
    }

    private void OnDisable()
    {
        boostButton.onClick.RemoveListener(OnButtonPress);
    }

    private void Update()
    {
        if (Game.Mothership.ShipMovement.BoostedSpeed)
        {
            progressIndicator.fillAmount = Game.Mothership.SpeedBoost.Progress;
        }
    }

    private void OnButtonPress()
    {
        if (!Game.Mothership.SpeedBoost.CanAfford) return;

        boostButton.interactable = false;
        Game.Mothership.SpeedBoost.ActivateBoost();
    }

    public void BoostComplete()
    {
        boostButton.interactable = true;
        progressIndicator.fillAmount = 0;
    }
}
