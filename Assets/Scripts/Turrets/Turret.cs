using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject turretBase;
    [SerializeField] GameObject pivot;

    public event Action OnFiring;

    [field: SerializeField] public CinemachineVirtualCamera Camera {  get; private set; }
    [field: SerializeField] public TurretTargeting Targeting { get; private set; }
    [field: SerializeField] public ProjectileLauncher ProjectileLauncher { get; private set; }
    [field: SerializeField] public TurretPower Power { get; private set; }
    [field: SerializeField] public EType Type { get; private set; }
    [field: SerializeField] public float Damage { get; private set; } = 10f;

    public EState State {  get; private set; }

    public enum EState
    {
        Unbuilt, // turret is hidden
        Buildable, // to show the slot can be built on in build mode
        Built // turret is built and ready to fire
    }

    public enum EType
    {
        Starboard,
        Port,
        Omnidirectional
    }

    private void Awake()
    {
        if (Power == null) Power = GetComponent<TurretPower>();
        if (Targeting == null) Targeting = GetComponentInChildren<TurretTargeting>();
        if (ProjectileLauncher == null) ProjectileLauncher = GetComponent<ProjectileLauncher>();
    }

    private void Start()
    {
        if (Type != EType.Omnidirectional) SetUnbuiltState();
        //else SetBuiltState();
    }

    public void SetUnbuiltState()
    {
        turretBase.SetActive(false);
        pivot.SetActive(false);

        State = EState.Unbuilt;
    }

    public void SetBuildableState()
    {
        turretBase.SetActive(true);
        pivot.SetActive(false);

        State = EState.Buildable;
    }

    public void SetBuiltState()
    {
        turretBase.SetActive(true);
        pivot.SetActive(true);

        State = EState.Built;
    }

    public bool CanAfford => Game.Mothership.Resources.CanAfford(Game.Mothership.BuildMode.TurretCost);

    public void Build()
    {
        Game.Mothership.Resources.RemoveResources(Game.Mothership.BuildMode.TurretCost);
        SetBuiltState();
    }

    public void Fire()
    {
        if (Power != null && !Power.CanFire) return;
        if (ProjectileLauncher != null && !ProjectileLauncher.CanFire) return; 

        if (Power != null) Power.ConsumeShotCost();
        if (ProjectileLauncher != null) ProjectileLauncher.Fire();

        Debug.Log(name + " firing");
        OnFiring?.Invoke();
    }
}
