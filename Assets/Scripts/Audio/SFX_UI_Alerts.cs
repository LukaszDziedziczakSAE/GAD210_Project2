using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_UI_Alerts : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip turretEmpty;
    [SerializeField] AudioClip turretRefilled;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null || audioSource == null) return;
        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayTurretEmpty()
    {
        PlaySound(turretEmpty);
    }

    public void PlayTurretRefilled()
    {
        PlaySound(turretRefilled);
    }
}
