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
            MenuLoop.HandleEvent(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
