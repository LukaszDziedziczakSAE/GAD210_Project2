using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TransportShipProgress : MonoBehaviour
{
    [SerializeField] RectTransform progressIndicator;
    [SerializeField] Image progressCircle;

    private void Update()
    {
        UpdateProgressLevel();
    }

    public void UpdateProgressLevel()
    {
        if (progressIndicator) progressIndicator.localScale = new Vector3(Game.TransportShip.ShipMovement.ProgressToWaypoint, 1, 1);

        if (progressCircle) progressCircle.fillAmount = Game.TransportShip.ShipMovement.ProgressToWaypoint;
    }
}
