using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [field: SerializeField] public ShipMovement ShipMovement { get; private set; }
}
