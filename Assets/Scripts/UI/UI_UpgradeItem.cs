using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_UpgradeItem : MonoBehaviour
{
    Upgrade_Base upgrade;
    [SerializeField] Button button;
    [SerializeField] TMP_Text text;

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonPress);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonPress);
    }

    public void Initilize(Upgrade_Base upgrade_Base)
    {
        upgrade = upgrade_Base;
        UpdateUI();
    }

    private void UpdateUI()
    {
        text.text = upgrade.UpgradeName + " Lvl." + upgrade.Level + "\n"
                    + "Next Level Cost: " + upgrade.CurrentCost;
    }

    private void OnButtonPress()
    {
        upgrade.ApplyUpgrade();
        UpdateUI();
    }
}
