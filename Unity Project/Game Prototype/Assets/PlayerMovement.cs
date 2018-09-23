using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public float runspeed = 40f;

    float horizontalMovement = 0f;
    bool jump = false;
	
	// Update is called once per frame
	void Update () {

        horizontalMovement = Input.GetAxisRaw("Horizontal") * runspeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
	}

    private void FixedUpdate()
    {
        //Move character
        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
