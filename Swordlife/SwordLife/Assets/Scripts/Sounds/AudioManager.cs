using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class AudioManager : MonoBehaviour {

    public Sounds[] sounds;
    public Slider Volume;

    public static AudioManager instance;


    void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }

    void Start()
    {
        Volume.value = PlayerPrefs.GetFloat("SFXVol");
    }

    void Update()
    {
        PlayerPrefs.SetFloat("SFXVol", Volume.value);

        foreach (Sounds s in sounds)
        {
            s.source.volume = PlayerPrefs.GetFloat("SFXVol");
        }
    }


    public void Play (string name)
    {
       Sounds s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
}
