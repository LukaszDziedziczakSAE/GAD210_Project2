using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TurretList : MonoBehaviour
{
    [SerializeField] UI_TurretListItem turretListItemPrefab;
    [SerializeField] Turret.EType side;
    List<UI_TurretListItem> list = new List<UI_TurretListItem>();

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
            if (turret.State != Turret.EState.Built) continue;

            UI_TurretListItem listItem = Instantiate(turretListItemPrefab, transform);
            listItem.Initilize(turret);
            list.Add(listItem);
        }
    }

    public void ClearList()
    {
        foreach (UI_TurretListItem item in list)
        {
            Destroy(item.gameObject);
        }

        list.Clear();
    }
}
