using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TurretListItem : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Button button;
    [SerializeField] Color foregroundColor;
    [SerializeField] Color backgroundColor;
    [SerializeField] Color lowForegroundColor;
    [SerializeField] Color lowBackgroundColor;
    [SerializeField] Image foreground;
    [SerializeField] Image background;
    [SerializeField] Image innerHub;

    Turret turret;

    public void Initilize(Turret turret)
    {
        this.turret = turret;
        UpdateListItem();
        this.turret.OnFiring += UpdateListItem;
        this.turret.OnRecharge += UpdateListItem;
        button.onClick.AddListener(OnButtonPress);
    }

    public void UpdateListItem()
    {
        text.text = turret.Power.CurrentPower.ToString()/* + " / " + turret.Power.MaxCapacity.ToString()*/;
        foreground.fillAmount = (float)turret.Power.CurrentPower / turret.Power.MaxCapacity;
        SetColors();
        if (turret.Power.CurrentPower == 0) UI.Sound.PlayTurretEmpty();
    }

    private void OnDisable()
    {
        this.turret.OnFiring -= UpdateListItem;
        this.turret.OnRecharge -= UpdateListItem;
        button.onClick.RemoveListener(OnButtonPress);
    }

    public void OnButtonPress()
    {
        //print("pressed recharge on " + turret.name);
        turret.Recharge();
        UI.Sound.PlayTurretRefilled();
    }

    private void SetColors()
    {
        if (turret.Power.CurrentPower > 0)
        {
            foreground.color = foregroundColor;
            background.color = backgroundColor;
            innerHub.color = foregroundColor;
        }

        else
        {
            foreground.color = lowForegroundColor;
            background.color = lowBackgroundColor;
            innerHub.color = lowForegroundColor;
        }
    }
}
