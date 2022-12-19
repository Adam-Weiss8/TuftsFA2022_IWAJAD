using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip song1;
    public AudioClip song2;
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = song1;
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void SwitchSong()
    {
        if (audioSource.clip == song1)
        {
            audioSource.clip = song2;
        }
        else
        {
            audioSource.clip = song1;
        }
    }
}
