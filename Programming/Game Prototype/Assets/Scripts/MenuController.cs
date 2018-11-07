using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //Change audio to Main Menu Audio
        AkSoundEngine.SetState("Music_State", "MenuState");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
