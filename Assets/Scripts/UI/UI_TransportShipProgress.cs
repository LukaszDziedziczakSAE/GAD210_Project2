using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TransportShipProgress : MonoBehaviour
{
    [SerializeField] RectTransform progressIndicator;

    private void Update()
    {
        UpdateProgressLevel();
    }

    public void UpdateProgressLevel()
    {
        progressIndicator.localScale = new Vector3(Game.TransportShip.ShipMovement.ProgressToWaypoint, 1, 1);
    }
}
