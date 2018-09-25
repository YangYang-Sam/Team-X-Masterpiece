using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public float runspeed = 40f;

    float horizontalMovement = 0f;
    bool jump = false;

    //[SerializeField]
    private bool plane1Invisible = false;
    //[SerializeField]
    private bool plane2Invisible = true;
    //[SerializeField]
    private bool plane3Invisible = true;

    private GameObject portal1;
    private GameObject portal2;
    private GameObject portal3;

    public const string Plane1Layer = "Foreground";
    public const string Plane2Layer = "Middleground";
    public const string Plane3Layer = "Background";
    public int sortingOrder = 0;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (sprite)
        {
            sprite.sortingOrder = sortingOrder;
            sprite.sortingLayerName = Plane1Layer;
        }

        Debug.Log(LayerMask.NameToLayer("Plane 1"));
        Debug.Log(LayerMask.NameToLayer("Plane 2"));
        Debug.Log(LayerMask.NameToLayer("Plane 3"));

    }


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
        portal1 = GameObject.Find("Portal 1");
        portal2 = GameObject.Find("Portal 2");
        portal3 = GameObject.Find("Portal 3");

        if (other.name == "Portal 1")
        {

                plane1Invisible = true;
                plane2Invisible = false;
                plane3Invisible = true;

            //GameObject.Find("Plane 1 Platforms").transform.localScale = new Vector3(0, 0, 0);
            Destroy(portal1.gameObject);
            sprite.sortingLayerName = Plane2Layer;

        }

        else if (other.name == "Portal 2")
            {

                plane1Invisible = true;
                plane2Invisible = true;
                plane3Invisible = false;

            //GameObject.Find("Plane 2 Platforms").transform.localScale = new Vector3(0, 0, 0);
            Destroy(portal2.gameObject);
            sprite.sortingLayerName = Plane3Layer;
        }

        else if (other.name == "Portal 3")
        {

                plane1Invisible = false;
                plane2Invisible = true;
                plane3Invisible = true;

            //GameObject.Find("Plane 3 Platforms").transform.localScale = new Vector3(0, 0, 0);
            Destroy(portal3.gameObject);
            sprite.sortingLayerName = Plane1Layer;

        }

    }

}
