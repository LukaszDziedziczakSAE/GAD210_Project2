using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShip : Ship
{
    [field: SerializeField] public EnemyAI AI { get; private set; }

    [field: SerializeField] public Turret Turret { get; private set; }

    private void Start()
    {
        Turret.SetBuiltState();
    }

}
