using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPulse : MonoBehaviour
{
    [SerializeField] ParticleSystem pulse;
    [SerializeField] float rate = 1f;
    float lastPulseTime;
    float timeSinceLastPulse => Time.time - lastPulseTime;

    private void Update()
    {
        if (timeSinceLastPulse >= rate)
        {
            StartPulse();
        }
    }

    private void StartPulse()
    {
        pulse.Play();
        lastPulseTime = Time.time;
    }
}
