using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{

    void Update()
    {
        transform.position = new Vector3(Game.Mothership.transform.position.x, transform.position.y, Game.Mothership.transform.position.z);
    }
}
