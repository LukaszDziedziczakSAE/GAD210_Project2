using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TurretInfoItem : MonoBehaviour
{
    [SerializeField] TMP_Text infoText;
    [SerializeField] Button button;
    [SerializeField] Color activeColor;
    [SerializeField] Image image;

    Turret turret;

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonPress);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonPress);
    }

    public void Initilize(Turret t)
    {
        turret = t;
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        if (turret == null) return;

        if (turret.State != Turret.EState.Built)
        {
            infoText.text = "Unbuilt Turret";
        }

        else // built turret
        {
            infoText.text = "Turret Online";
            image.color = activeColor;
        }
    }

    public void OnButtonPress()
    {
        if (turret.State != Turret.EState.Built)
        {
            turret.Build();
            UpdateInfo();
        }

        else // built turret
        {
            Game.Mothership.TurretUpgradeMode.EnterTurretUpgradeMode(turret);
        }
    }
}
