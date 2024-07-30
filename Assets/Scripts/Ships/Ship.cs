using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [field: SerializeField] public ShipMovement ShipMovement { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public EType Type { get; private set; }

    public enum EType
    {
        None,
        Enemy,
        Transport,
        Mothership
    }
}
