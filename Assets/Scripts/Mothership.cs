using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{
    public static Mothership Instance { get; private set; }
    [field: SerializeField] public EnemyWaypoint ForwardStarboardWaypoint {  get; private set; }
    [field: SerializeField] public EnemyWaypoint ForwardPortWaypoint { get; private set; }
    [field: SerializeField] public EnemyWaypoint AftStarboardWaypoint { get; private set; }
    [field: SerializeField] public EnemyWaypoint AftPortWaypoint { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
}
