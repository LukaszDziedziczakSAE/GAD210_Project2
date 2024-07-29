using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TurretListItem : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Button button;

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
        text.text = turret.Power.CurrentPower.ToString() + " / " + turret.Power.MaxCapacity.ToString();
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
    }
}
