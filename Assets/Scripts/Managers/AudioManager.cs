using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    void Start()
    {
        PlaySound("MenuMusic");
    }

    public void PlaySound(string soundName)
    {
        Sound foundSound = Array.Find(sounds, sound => sound.name == soundName);

        if(foundSound != null)
        {
            foundSound.source.Play();
        } 
    }

    internal void StopSound(string soundName)
    {
        Sound foundSound = Array.Find(sounds, sound => sound.name == soundName);

        if (foundSound != null)
        {
            foundSound.source.Stop();
        }
    }
}
