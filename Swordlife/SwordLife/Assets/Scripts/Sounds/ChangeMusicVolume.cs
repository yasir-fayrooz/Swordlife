using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ChangeMusicVolume : MonoBehaviour {

    public Slider Volume;
    private AudioSource[] MyMusic;

    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVol"))
        {
            PlayerPrefs.SetFloat("MusicVol", 1);
        }
        else
        {
            Volume.value = PlayerPrefs.GetFloat("MusicVol");
        }
        MyMusic = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainMenuCamera>().sounds;
    }
	// Update is called once per frame
	void Update ()
    {
        PlayerPrefs.SetFloat("MusicVol", Volume.value);

        foreach (AudioSource music in MyMusic)
        {
            music.volume = PlayerPrefs.GetFloat("MusicVol");
        }
    }
}
