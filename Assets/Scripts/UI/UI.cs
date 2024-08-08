using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }
    [SerializeField] UI_PowerIndicator powerIndicator;
    [SerializeField] UI_ResourcesIndicator resourcesIndicator;
    [SerializeField] UI_View_Tactical tacticalView;
    [SerializeField] UI_View_Mothership mothershipView;
    [SerializeField] UI_View_Upgrade turretView;
    [SerializeField] UI_HealthIndicator mothershipHealthIndicator;
    [SerializeField] UI_HealthIndicator transportShipHealthIndicator;
    [SerializeField] SFX_UI_Alerts uiAlerts;

    bool mouseOverUI;

    public static bool MouseOverUI => Instance.mouseOverUI;
    public static UI_View_Tactical TacticalView => Instance.tacticalView;
    public static UI_View_Mothership MothershipView => Instance.mothershipView;
    public static UI_View_Upgrade TurretView => Instance.turretView;
    public static SFX_UI_Alerts Sound => Instance.uiAlerts;

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
        Instance.turretView.gameObject.SetActive(false);
        Instance.mothershipView.gameObject.SetActive(false);
        Instance.tacticalView.gameObject.SetActive(true);
        UI.Sound.PlayTacticalViewSelected();
    }

    public static void SwitchToMothershipView()
    {
        Instance.turretView.gameObject.SetActive(false);
        Instance.tacticalView.gameObject.SetActive(false);
        Instance.mothershipView.gameObject.SetActive(true);
        UI.Sound.PlayMothershipSelected();
    }

    public static void SwitchToTurretView()
    {
        Instance.mothershipView.gameObject.SetActive(false);
        Instance.tacticalView.gameObject.SetActive(false);
        Instance.turretView.gameObject.SetActive(true);
        UI.Sound.PlayTurretSelected();
    }

    public static void UpdateMothershipHealthIndicator()
    {
        if (Instance.mothershipHealthIndicator) Instance.mothershipHealthIndicator.UpdateHealthLevel();
    }

    public static void UpdateTransportShipHealthIndicator()
    {
        if (Instance.transportShipHealthIndicator) Instance.transportShipHealthIndicator.UpdateHealthLevel();
    }

    public static void SetMouseOverUI(bool isOverUI)
    {
        Instance.mouseOverUI = isOverUI;
    }
}
