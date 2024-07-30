using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Music : MonoBehaviour
{
    AudioSource musicSource;

    [SerializeField] AudioClip[] musicClips;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!musicSource.isPlaying) PlayMusic();
    }

    public void PlayMusic()
    {
        musicSource.clip = musicClips[Random.Range(0, musicClips.Length)];
        musicSource.Play();
    }
}
