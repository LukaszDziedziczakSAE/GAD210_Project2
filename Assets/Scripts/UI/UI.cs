using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }
    [SerializeField] UI_PowerIndicator powerIndicator;
    [SerializeField] UI_ResourcesIndicator resourcesIndicator;
    [SerializeField] UI_View_Tactical tacticalView;
    [SerializeField] GameObject mothershipView;
    [SerializeField] GameObject turretView;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        SwitchToPlayView();
    }

    public static void UpdatePowerIndicator()
    {
        if (Instance.powerIndicator != null) Instance.powerIndicator.UpdatePowerLevel();
    }

    public static void UpdateResourceIndicator()
    {
        if (Instance.resourcesIndicator != null) Instance.resourcesIndicator.UpdateResourceIndicator();
    }

    public static void SwitchToPlayView()
    {
        Instance.turretView.SetActive(false);
        Instance.mothershipView.SetActive(false);
        Instance.tacticalView.gameObject.SetActive(true);
    }

    public static void SwitchToMothershipView()
    {
        Instance.turretView.SetActive(false);
        Instance.tacticalView.gameObject.SetActive(false);
        Instance.mothershipView.SetActive(true);
    }

    public static void SwitchToTurretView()
    {
        Instance.mothershipView.SetActive(false);
        Instance.tacticalView.gameObject.SetActive(false);
        Instance.turretView.SetActive(true);
    }
}
