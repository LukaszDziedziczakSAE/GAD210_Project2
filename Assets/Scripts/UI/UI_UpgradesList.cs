using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UpgradesList : MonoBehaviour
{
    [SerializeField] UI_UpgradeItem upgradeItemPrefab;
    MothershipTurretUpgradeMode upgradeMode => Game.Mothership.TurretUpgradeMode;
    List<UI_UpgradeItem> list = new List<UI_UpgradeItem>();

    private void OnEnable()
    {
        BuildList();
    }

    private void OnDisable()
    {
        ClearList();
    }

    private void BuildList()
    {
        foreach (Upgrade_Base upgrade in upgradeMode.SelectedTurret.Upgrades)
        {
            UI_UpgradeItem upgradeItem = Instantiate(upgradeItemPrefab, transform);
            upgradeItem.Initilize(upgrade);
            list.Add(upgradeItem);
        }
    }

    private void ClearList()
    {
        foreach (UI_UpgradeItem upgradeItem in list)
        {
            Destroy(upgradeItem.gameObject);
        }
        list.Clear();
    }
}
