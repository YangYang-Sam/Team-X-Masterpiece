using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R pressed");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc pressed");
            //AkSoundEngine.SetRTPCValue("Game_Pause", 0f, GameObject.Find("AztecLoop"), 2000);
            SceneManager.LoadScene(0);
        }
    }
}
