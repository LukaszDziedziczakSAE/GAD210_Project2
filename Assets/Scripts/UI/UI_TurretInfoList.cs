using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TurretInfoList : MonoBehaviour
{
    [SerializeField] UI_TurretInfoItem turretInfoItemPrefab;
    [SerializeField] Turret.EType side;

    List<UI_TurretInfoItem> turretInfoItems = new List<UI_TurretInfoItem>();

    private Turret[] turrets
    {
        get
        {
            if (side == Turret.EType.Starboard) return Game.Mothership.StarboardTurrets;
            else if (side == Turret.EType.Port) return Game.Mothership.PortTurrets;
            else return new Turret[0];
        }
    }

    public void RedrawList()
    {
        ClearList();

        foreach (Turret turret in turrets)
        {
            UI_TurretInfoItem listItem = Instantiate(turretInfoItemPrefab, transform);
            listItem.Initilize(turret);
            turretInfoItems.Add(listItem);
        }
    }

    public void ClearList()
    {
        foreach (UI_TurretInfoItem item in turretInfoItems)
        {
            Destroy(item.gameObject);
        }

        turretInfoItems.Clear();
    }
}
