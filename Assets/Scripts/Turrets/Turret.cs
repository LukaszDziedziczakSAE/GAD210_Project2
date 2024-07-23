using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject turretBase;
    [SerializeField] GameObject pivot;
    [field: SerializeField] public CinemachineVirtualCamera Camera {  get; private set; }
    [field: SerializeField] public TurretTargeting Targeting { get; private set; }
    [field: SerializeField] public ProjectileLauncher ProjectileLauncher { get; private set; }

    public EState State {  get; private set; }

    private void Start()
    {
        SetUnbuiltState();
    }

    public enum EState
    {
        Unbuilt, // turret is hidden
        Buildable, // to show the slot can be built on in build mode
        Built // turret is built and ready to fire
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
}
