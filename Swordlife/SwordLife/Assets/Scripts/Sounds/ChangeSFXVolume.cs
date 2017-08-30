using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ChangeSFXVolume : MonoBehaviour {

    public Slider Volume;
    public Sounds[] MySFX;

    private float Vol;

    void Start()
    {
        Volume.value = PlayerPrefs.GetFloat("SFXVol");
        Vol = PlayerPrefs.GetFloat("SFXVol");
    }
	// Update is called once per frame
	void Update ()
    {
        if(Vol != Volume.value)
        {
            PlayerPrefs.SetFloat("SFXVol", Volume.value);
        }

        foreach (Sounds s in MySFX)
        {
            s.volume = PlayerPrefs.GetFloat("SFXVol");
        }
	}
}
