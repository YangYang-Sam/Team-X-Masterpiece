using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneNavigation : MonoBehaviour {

    // sets player collisions based on layer/plane
    //[SerializeField]
    private bool plane1Invisible = false;
    //[SerializeField]
    private bool plane2Invisible = true;
    //[SerializeField]
    private bool plane3Invisible = true;


    //sets each portal as accessible GameObject
    private GameObject portal1;
    private GameObject portal2;
    private GameObject portal3;

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
        //sets collision layers as layer numbers
        PlayerCollisionLayer = LayerMask.NameToLayer("Player");
        Plane1CollisionLayer = LayerMask.NameToLayer("Plane 1");
        Plane2CollisionLayer = LayerMask.NameToLayer("Plane 2");
        Plane3CollisionLayer = LayerMask.NameToLayer("Plane 3");

        //save portal name as variable
        portal1 = GameObject.Find("Portal 1");
        portal2 = GameObject.Find("Portal 2");
        portal3 = GameObject.Find("Portal 3");

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

            //turn on/off collisions for appropriate layer
            plane1Invisible = true;
            plane2Invisible = false;
            plane3Invisible = true;

            //GameObject.Find("Plane 1 Platforms").transform.localScale = new Vector3(0, 0, 0);
            //Destroy(portal1.gameObject);

            //Make player sprite render on correct layer
            sprite.sortingLayerName = Plane2SortingLayer;

        }

        else if (other.name == "Portal 2")
        {

            plane1Invisible = true;
            plane2Invisible = true;
            plane3Invisible = false;

            //GameObject.Find("Plane 2 Platforms").transform.localScale = new Vector3(0, 0, 0);
            //Destroy(portal2.gameObject);

            //Make player sprite render on correct layer
            sprite.sortingLayerName = Plane3SortingLayer;
        }

        else if (other.name == "Portal 3")
        {

            plane1Invisible = false;
            plane2Invisible = true;
            plane3Invisible = true;

            //GameObject.Find("Plane 3 Platforms").transform.localScale = new Vector3(0, 0, 0);
            //Destroy(portal3.gameObject);

            //Make player sprite render on correct layer
            sprite.sortingLayerName = Plane1SortingLayer;

        }

    }
}
