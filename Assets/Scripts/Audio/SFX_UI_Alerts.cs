using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_UI_Alerts : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip turretEmpty;
    [SerializeField] AudioClip turretRefilled;
    [SerializeField] AudioClip turretBuilt;
    [SerializeField] AudioClip turretUpgraded;
    [SerializeField] AudioClip mothershipSelected;
    [SerializeField] AudioClip turretSelected;
    [SerializeField] AudioClip tacticalViewSelected;
    [SerializeField] AudioClip unable;

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

    public void PlayTurretBuilt()
    {
        PlaySound(turretBuilt);
    }

    public void PlayTurretUpgraded()
    {
        PlaySound(turretUpgraded);
    }

    public void PlayTurretSelected()
    {
        PlaySound(turretSelected);
    }

    public void PlayMothershipSelected()
    {
        PlaySound(mothershipSelected);
    }

    public void PlayTacticalViewSelected()
    {
        PlaySound(tacticalViewSelected);
    }

    public void PlayUnable()
    {
        PlaySound(unable);
    }
}
