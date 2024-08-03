using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_StartingAudio : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayStartSound();
    }

    public void PlayStartSound()
    {
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.Play();
    }
}
