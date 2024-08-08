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
    [field: SerializeField] public MothershipSpeedBoost SpeedBoost { get; private set; }
    [field: SerializeField] public MothershipPowerplant Powerplant { get; private set; }

    public Turret[] BuiltTurrets
    {
        get
        {
            List<Turret> turrets = new List<Turret>();
            foreach (Turret turret in Turrets)
            {
                if (turret.State == Turret.EState.Built) turrets.Add(turret);
            }

            return turrets.ToArray();
        }
    }

    public Turret[] StarboardTurrets
    {
        get
        {
            List<Turret> turrets = new List<Turret>();
            foreach (Turret turret in Turrets)
            {
                if (turret.Type == Turret.EType.Starboard) turrets.Add(turret);
            }

            return turrets.ToArray();
        }
    }

    public Turret[] PortTurrets
    {
        get
        {
            List<Turret> turrets = new List<Turret>();
            foreach (Turret turret in Turrets)
            {
                if (turret.Type == Turret.EType.Port) turrets.Add(turret);
            }

            return turrets.ToArray();
        }
    }

    public Turret[] GetPortTurrets()
    {
        List<Turret> turrets = new List<Turret>();
        foreach (Turret turret in Turrets)
        {
            if (turret.State == Turret.EState.Built && turret.Type == Turret.EType.Port) turrets.Add(turret);
        }

        return turrets.ToArray();
    }
}
