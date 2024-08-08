using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipPowerplant : MonoBehaviour
{
    [field: SerializeField] public CinemachineVirtualCamera Camera { get; private set; }
    [field: SerializeField] public Upgrade_Base[] Upgrades { get; private set; }
}
