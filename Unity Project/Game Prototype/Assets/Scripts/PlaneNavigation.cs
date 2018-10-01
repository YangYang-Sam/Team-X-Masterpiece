using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneNavigation : MonoBehaviour {

    //Access playerController class
    private PlayerController2D playerController2D;

    //public Animator animator;

    GameObject Plane1;
    GameObject Plane2;
    GameObject Plane3;

    // sets player collisions based on layer/plane
    //[SerializeField]
    private bool plane1Invisible = false;
    //[SerializeField]
    private bool plane2Invisible = true;
    //[SerializeField]
    private bool plane3Invisible = true;


    public const string Plane1SortingLayer = "Foreground";
    public const string Plane2SortingLayer = "Middleground";
    public const string Plane3SortingLayer = "Background";

    //sets sorting order for player to 0 (on top)
    public int sortingOrder = 0;

    //creates SpriteRenderer component to manipulate layer order.
    private SpriteRenderer sprite;

    private int PlayerCollisionLayer;
    private int Plane1CollisionLayer;
    private int Plane2CollisionLayer;
    private int Plane3CollisionLayer;

    // Use this for initialization
    void Start ()
    {
        //set gameobjects for plane scaling
        Plane1 = GameObject.Find("Plane 1");
        Plane2 = GameObject.Find("Plane 2");
        Plane3 = GameObject.Find("Plane 3");

        //Plane1.transform.localScale = new Vector2(1, 1);
        //Plane2.transform.localScale = new Vector2(0, 0);
        //Plane3.transform.localScale = new Vector2(0, 0);

        playerController2D = GetComponent<PlayerController2D>();
        playerController2D.whatIsGround = LayerMask.GetMask("Plane 1");
        //sets collision layers as layer numbers
        PlayerCollisionLayer = LayerMask.NameToLayer("Player");
        Plane1CollisionLayer = LayerMask.NameToLayer("Plane 1");
        Plane2CollisionLayer = LayerMask.NameToLayer("Plane 2");
        Plane3CollisionLayer = LayerMask.NameToLayer("Plane 3");

        //prints layer numbers
        Debug.Log(PlayerCollisionLayer);
        Debug.Log(Plane1CollisionLayer);
        Debug.Log(Plane2CollisionLayer);
        Debug.Log(Plane3CollisionLayer);

        //sets sprite variable to SpriteRenderer component
        sprite = GetComponent<SpriteRenderer>();

        if (sprite)
        {
            sprite.sortingOrder = sortingOrder;
            sprite.sortingLayerName = Plane1SortingLayer;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Sets the collisions between layer 8 (player) and platform layers
        Physics2D.IgnoreLayerCollision(PlayerCollisionLayer, Plane1CollisionLayer, plane1Invisible);
        Physics2D.IgnoreLayerCollision(PlayerCollisionLayer, Plane2CollisionLayer, plane2Invisible);
        Physics2D.IgnoreLayerCollision(PlayerCollisionLayer, Plane3CollisionLayer, plane3Invisible);
    }

    //detect player colliding with portal
    private void OnTriggerEnter2D(Collider2D other)

    {
        Debug.Log("Collided with: " + other.name);

        //switch to correct layer based on portal name
        if (other.name == "Portal 1")
        {
            Plane2Selector();
        }

        else if (other.name == "Portal 2")
        {
            Plane3Selector();
        }

        else if (other.name == "Portal 3")
        {
            Plane1Selector();
        }

    }

    private void Plane1Selector()
    {
        Plane3.GetComponent<Animator>().Play("Plane3_Out");
        Plane2.GetComponent<Animator>().Play("Plane2_Out_Middle");
        Plane1.GetComponent<Animator>().Play("Plane1_In_From3");

        //turn on/off collisions for appropriate layer
        plane1Invisible = false;
        plane2Invisible = true;
        plane3Invisible = true;

        //Plane1.transform.localScale = new Vector2(1, 1);
        //Plane2.transform.localScale = new Vector2(0, 0);
        //Plane3.transform.localScale = new Vector2(0, 0);

        playerController2D.whatIsGround = LayerMask.GetMask("Plane 1");

        //Make player sprite render on correct layer
        sprite.sortingLayerName = Plane1SortingLayer;
    }

    private void Plane2Selector()
    {
        Plane2.GetComponent<Animator>().Play("Plane2_In");
        Plane1.GetComponent<Animator>().Play("Plane1_Out");
        Plane3.GetComponent<Animator>().Play("Plane3_In_BG");
        plane1Invisible = true;
        plane2Invisible = false;
        plane3Invisible = true;

        //Plane1.transform.localScale = new Vector2(0, 0);
        //Plane2.transform.localScale = new Vector2(1, 1);
        //Plane3.transform.localScale = new Vector2(0, 0);

        playerController2D.whatIsGround = LayerMask.GetMask("Plane 2");

        //Make player sprite render on correct layer
        sprite.sortingLayerName = Plane2SortingLayer;
    }

    private void Plane3Selector()
    {
        Plane2.GetComponent<Animator>().Play("Plane2_Out");
        Plane3.GetComponent<Animator>().Play("Plane3_In");
        plane1Invisible = true;
        plane2Invisible = true;
        plane3Invisible = false;

        Plane1.transform.localScale = new Vector2(0, 0);
        Plane2.transform.localScale = new Vector2(0, 0);
        Plane3.transform.localScale = new Vector2(1, 1);

        playerController2D.whatIsGround = LayerMask.GetMask("Plane 3");

        //Make player sprite render on correct layer
        sprite.sortingLayerName = Plane3SortingLayer;
    }

}

