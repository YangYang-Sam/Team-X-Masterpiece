using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public AkEvent MenuLoop;

	// Use this for initialization
	void Start ()
    {
        if (MenuLoop != null)
        {
            //MenuLoop.HandleEvent(gameObject);
            //AkSoundEngine.SetRTPCValue("Menu_Music", 0f, GameObject.Find("MenuLoop"), 0);
            //AkSoundEngine.SetRTPCValue("Menu_Music", 60f, GameObject.Find("MenuLoop"), 3000);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
