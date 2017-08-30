using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ChangeMusicVolume : MonoBehaviour {

    public Slider Volume;
    public AudioSource MyMusic;

    private float Vol;

    void Start()
    {
        Volume.value = PlayerPrefs.GetFloat("MusicVol");
        Vol = PlayerPrefs.GetFloat("MusicVol");
    }
	// Update is called once per frame
	void Update ()
    {
        if(Vol != Volume.value)
        {
            PlayerPrefs.SetFloat("MusicVol", Volume.value);
        }
        MyMusic.volume = PlayerPrefs.GetFloat("MusicVol");
	}
}
