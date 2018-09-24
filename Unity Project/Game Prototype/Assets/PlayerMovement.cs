using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public float runspeed = 40f;

    float horizontalMovement = 0f;
    bool jump = false;

    [SerializeField]
    private bool plane1Invisible = false;
    [SerializeField]
    private bool plane2Invisible = true;
    [SerializeField]
    private bool plane3Invisible = true;

    // Update is called once per frame
    void Update () {

        horizontalMovement = Input.GetAxisRaw("Horizontal") * runspeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Ignore the collisions between layer 8 (player) and platform layers
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        if (other.tag == "Portal")
        {

            if (plane1Invisible == false)
            {

                plane1Invisible = true;
                plane2Invisible = false;
                plane3Invisible = true;

                //hide plane1 platforms
                //GameObject.Find("Plane1 Platforms").transform.localScale = new Vector3(0, 0, 0);
                //GameObject.Find("Plane2 Platforms").transform.localScale = new Vector3(1, 1, 1);
                //GameObject.Find("Plane3 Platforms").transform.localScale = new Vector3(1, 1, 1);

            }
            

        }

    }

}
