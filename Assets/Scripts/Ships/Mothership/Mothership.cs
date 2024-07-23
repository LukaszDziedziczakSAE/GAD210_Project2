using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : CapitalShip
{
    [field: SerializeField, Header("Mothership References")] public CinemachineVirtualCamera Camera { get; private set; }
    [field: SerializeField] public Turret[] Turrets { get; private set; }
    [field: SerializeField] public MothershipBuildMode BuildMode { get; private set; }
    [field: SerializeField] public MothershipPower Power { get; private set; }
    [field: SerializeField] public MothershipResources Resources { get; private set; }
    [field: SerializeField] public MothershipTurretUpgradeMode TurretUpgradeMode { get; private set; }
}
