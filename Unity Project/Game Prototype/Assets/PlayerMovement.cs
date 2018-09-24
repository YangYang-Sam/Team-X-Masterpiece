using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public float runspeed = 40f;

    float horizontalMovement = 0f;
    bool jump = false;

    [SerializeField]
    private bool plane1Invisible;
    [SerializeField]
    private bool plane2Invisible;
    [SerializeField]
    private bool plane3Invisible;

    // Update is called once per frame
    void Update () {

        horizontalMovement = Input.GetAxisRaw("Horizontal") * runspeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Ignore the collisions between layer 0 (default) and layer 8 (custom layer you set in Inspector window)
        Physics2D.IgnoreLayerCollision(8, 10, plane1Invisible);
        Physics2D.IgnoreLayerCollision(8, 11, plane2Invisible);
        Physics2D.IgnoreLayerCollision(8, 12, plane3Invisible);
    }

    private void FixedUpdate()
    {
        //Move character
        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    //Detect when there is a collision
    void OnCollisionEnter(Collision other)
    {
        //Output the name of the GameObject you collide with
        Debug.Log("I hit the GameObject : " + other.gameObject.tag);
    }
}
