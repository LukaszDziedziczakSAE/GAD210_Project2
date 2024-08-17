using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MothershipModuleInfo : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] TMP_Text moduleLabel;
    MothershipModule mothershipModule;

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonPress);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonPress);
    }

    public void Initilize(MothershipModule mm)
    {
        mothershipModule = mm;
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        if (mothershipModule == null) return;

        moduleLabel.text = mothershipModule.ModuleName;
    }

    public void OnButtonPress()
    {
        if (mothershipModule != null) Game.Mothership.UpgradeMode.EnterUpgradeMode(mothershipModule);
    }
}
