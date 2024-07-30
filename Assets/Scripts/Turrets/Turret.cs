using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [field: SerializeField] public bool ShowDebugs { get; private set; }
    [SerializeField] GameObject turretBase;
    [SerializeField] GameObject turretHead;
    [SerializeField] Transform pivot;

    public event Action OnFiring;
    public event Action OnRecharge;

    [field: SerializeField] public CinemachineVirtualCamera Camera {  get; private set; }
    [field: SerializeField] public TurretTargeting Targeting { get; private set; }
    [field: SerializeField] public ProjectileLauncher ProjectileLauncher { get; private set; }
    [field: SerializeField] public TurretPower Power { get; private set; }
    [field: SerializeField] public EState State {  get; private set; }
    [field: SerializeField] public EType Type { get; private set; }
    [field: SerializeField] public float Damage { get; private set; } = 10f;
    [field: SerializeField] public float PowerCostPerShot { get; private set; } = 10f;
    [field: SerializeField] public float FiringAngle { get; private set; } = 60f;

    Mothership mothership;
    [field: SerializeField] public bool IsEnemy { get; private set; }


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
        if (mothership == null) mothership = GetComponentInParent<Mothership>();
    }

    private void Start()
    {
        if (Type != EType.Omnidirectional) SetUnbuiltState();
        //else SetBuiltState();

        if (Targeting == null) Debug.LogError(name + " missing Targeting referance");
    }

    private void Update()
    {
        //if (ShowDebugs) print(name + " update");

        if (Targeting != null)
        {
            Ship target = Targeting.Target;
            if (ShowDebugs) Debug.Log(name + " target = " + (target != null).ToString() + ", HasTargetInRange = " + Targeting.HasTargetInRange);
            if (target != null)
            {
                if (ShowDebugs) Debug.Log(name + " has heading " + Targeting.HeadingTowardTarget);
                SetPivot(Targeting.HeadingTowardTarget);
                Fire();
            }
            else if (Targeting.HasTargetInRange && target == null)
            {
                Debug.LogWarning(name + " targetting failur");
            }
            else SetPivot(transform.eulerAngles.y);

        }
    }

    public void SetUnbuiltState()
    {
        turretBase.SetActive(false);
        turretHead.SetActive(false);

        State = EState.Unbuilt;
    }

    public void SetBuildableState()
    {
        turretBase.SetActive(true);
        turretHead.SetActive(false);

        State = EState.Buildable;
    }

    public void SetBuiltState()
    {
        turretBase.SetActive(true);
        turretHead.SetActive(true);

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
        if (ShowDebugs) Debug.Log(name + " starting firing seqence");
        if (Power != null && !Power.CanFire) return;
        if (ProjectileLauncher != null && !ProjectileLauncher.CanFire) return; 

        if (Power != null) Power.ConsumeShotCost();
        if (ProjectileLauncher != null) ProjectileLauncher.Fire(Targeting.TargetPosition);
        else Debug.LogError(name + " missing ProjectileLauncher referance");

        if (ShowDebugs) Debug.Log(name + " firing");
        OnFiring?.Invoke();
    }

    public void Recharge()
    {
        if (mothership.Power.CanAfford(PowerCostPerShot, out int amount))
        {
            //Debug.Log(name + " can afford to recharge " + amount);
            int amountToRecharge = Mathf.Clamp(amount, 0, Power.PowerNeeded);
            mothership.Power.UsePower(amountToRecharge * PowerCostPerShot);
            Power.Resupply(amountToRecharge);
        }
        else
        {
            //Debug.Log(name + " cannot afford to recharge");
        }

        OnRecharge?.Invoke();
    }

    public void SetPivot(float angle)
    {
        if (Type != EType.Port) angle += 180;
        if (pivot != null) pivot.eulerAngles = new Vector3 (pivot.eulerAngles.x, angle, pivot.eulerAngles.z);
    }

    public void SetPivot(Vector3 target)
    {
    }
}
