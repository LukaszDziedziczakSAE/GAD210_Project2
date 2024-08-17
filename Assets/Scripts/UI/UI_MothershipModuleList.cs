using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MothershipModuleList : MonoBehaviour
{
    [SerializeField] UI_MothershipModuleInfo mothershipModuleInfoPrefab;
    List<UI_MothershipModuleInfo> list = new List<UI_MothershipModuleInfo>();
    MothershipModule[] modules => Game.Mothership.Modules;

    public void RedrawList()
    {
        ClearList();

        foreach (MothershipModule module in modules)
        {
            UI_MothershipModuleInfo listItem = Instantiate(mothershipModuleInfoPrefab, transform);
            listItem.Initilize(module);
            list.Add(listItem);
        }
    }

    public void ClearList()
    {
        if (list.Count == 0) return;

        foreach (UI_MothershipModuleInfo item in list)
        {
            Destroy(item.gameObject);
        }

        list.Clear();
    }
}
