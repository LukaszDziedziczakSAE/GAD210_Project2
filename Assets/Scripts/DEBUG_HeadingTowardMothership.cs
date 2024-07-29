using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_HeadingTowardMothership : MonoBehaviour
{
    private void Update()
    {
        print(HeadingToward(Game.Mothership.transform.position) - transform.eulerAngles.y);
    }


    public float HeadingToward(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        float angle = /*transform.eulerAngles.y -*/ (Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg) - 90;
        //if (angle > 180) angle -= 360;
        return -angle;
    }
}
