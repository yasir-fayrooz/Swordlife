using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ChangeMusicVolume : MonoBehaviour {

    public Slider Volume;
    public AudioSource MyMusic;

    void Start()
    {
        Volume.value = PlayerPrefs.GetFloat("MusicVol");
    }
	// Update is called once per frame
	void Update ()
    {
        PlayerPrefs.SetFloat("MusicVol", Volume.value);

        MyMusic.volume = PlayerPrefs.GetFloat("MusicVol");
	}
}
