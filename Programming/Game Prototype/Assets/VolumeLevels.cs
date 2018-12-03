using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeLevels : MonoBehaviour {

    [SerializeField]
    private Slider thisSlider;
    private float musicVolume;
    private float SFXVolume;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void setVolume(string whatVolume)
    {
        float sliderValue = thisSlider.value;

        if(whatVolume == "Music")
        {
            musicVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("MusicVolume", musicVolume);
        }

        if (whatVolume == "SoundFX")
        {
            SFXVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("SFXVolume", SFXVolume);
        }
    }
}
