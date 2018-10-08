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
    [SerializeField]
    private bool plane1Ignore = false;
    [SerializeField]
    private bool plane2Ignore = true;
    [SerializeField]
    private bool plane3Ignore = true;


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

    [SerializeField]
    public bool _playerFrozen;
    [SerializeField]
    public float freezeTime;
    //how long should we freeze for.

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

        //sets sprite variable to SpriteRenderer component
        sprite = GetComponent<SpriteRenderer>();

        if (sprite)
        {
            sprite.sortingOrder = sortingOrder;
            sprite.sortingLayerName = Plane1SortingLayer;
            sprite.sortingOrder = 1;
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Sets the collisions between layer 8 (player) and platform layers
        Physics2D.IgnoreLayerCollision(PlayerCollisionLayer, Plane1CollisionLayer, plane1Ignore);
        Physics2D.IgnoreLayerCollision(PlayerCollisionLayer, Plane2CollisionLayer, plane2Ignore);
        Physics2D.IgnoreLayerCollision(PlayerCollisionLayer, Plane3CollisionLayer, plane3Ignore);
    }

    //detect player colliding with portal
    private void OnTriggerStay2D(Collider2D other)

    {
        //switch to correct layer based on portal name
        if (other.name == "Portal 1" && Input.GetButtonDown("Interact"))
        {
            Plane2Selector();
        }

        else if (other.name == "Portal 2" && Input.GetButtonDown("Interact"))
        {
            Plane3Selector();
        }

        else if (other.name == "Portal 3" && Input.GetButtonDown("Interact"))
        {
            Plane1Selector();
        }

    }

    private void Plane1Selector()
    {
        StartCoroutine(Plane1Delay());
        Plane3.GetComponent<Animator>().Play("Plane3_Out");
        Plane2.GetComponent<Animator>().Play("Plane2_Out_Middle");
        Plane1.GetComponent<Animator>().Play("Plane1_In_From3");

        //turn on/off collisions for appropriate layer
        plane1Ignore = false;
        plane2Ignore = true;
        plane3Ignore = true;
        FindObjectOfType<AudioManager>().Play("PortalEntry");

        playerController2D.whatIsGround = LayerMask.GetMask("Plane 1");

        //Make player sprite render on correct layer
        sprite.sortingLayerName = Plane1SortingLayer;
    }

    private void Plane2Selector()
    {
        StartCoroutine(Plane2Delay());
        Plane2.GetComponent<Animator>().Play("Plane2_In");
        Plane1.GetComponent<Animator>().Play("Plane1_Out");
        Plane3.GetComponent<Animator>().Play("Plane3_In_BG");
        //plane1Ignore = true;
        //plane2Ignore = false;
        //plane3Ignore = true;
        FindObjectOfType<AudioManager>().Play("PortalEntry");

        //playerController2D.whatIsGround = LayerMask.GetMask("Plane 2");

        //Make player sprite render on correct layer
        //sprite.sortingLayerName = Plane2SortingLayer;
    }

    private void Plane3Selector()
    {
        StartCoroutine(Plane3Delay());
        Plane2.GetComponent<Animator>().Play("Plane2_Out");
        Plane3.GetComponent<Animator>().Play("Plane3_In");
        //plane1Ignore = true;
        //plane2Ignore = true;
        //plane3Ignore = false;
        FindObjectOfType<AudioManager>().Play("PortalEntry");

        playerController2D.whatIsGround = LayerMask.GetMask("Plane 3");

        //Make player sprite render on correct layer
        sprite.sortingLayerName = Plane3SortingLayer;
    }

    public IEnumerator FreezePlayer()
    {
        float time = 0;

        while (time < freezeTime)
        {
            time += Time.deltaTime;
            _playerFrozen = true;
            //plane1Ignore = true;
            //plane2Ignore = true;
            //plane3Ignore = true;
            yield return null;
        }
        //Turn back to the starting position.
        if (time > 0)
        {
            time -= Time.deltaTime;
            plane1Ignore = true;
            plane2Ignore = false;
            plane3Ignore = true;
            playerController2D.whatIsGround = LayerMask.GetMask("Plane 2");
            sprite.sortingLayerName = Plane2SortingLayer;
            _playerFrozen = false;
            Debug.Log("Number of calls");
            yield return null;
        }
        //_playerFrozen = false;
    }

    public IEnumerator Plane1Delay()
    {
        float time = 0;

        while (time < freezeTime)
        {
            time += Time.deltaTime;
            _playerFrozen = true;
            plane1Ignore = true;
            plane2Ignore = true;
            plane3Ignore = true;
            yield return null;
        }
        //Turn back to the starting position.
        if (time > 0)
        {
            time -= Time.deltaTime;
            plane1Ignore = false;
            plane2Ignore = true;
            plane3Ignore = true;
            playerController2D.whatIsGround = LayerMask.GetMask("Plane 1");
            sprite.sortingLayerName = Plane1SortingLayer;
            _playerFrozen = false;
            Debug.Log("Number of calls");
            yield return null;
        }
    }

    public IEnumerator Plane2Delay()
    {
        float time = 0;

        while (time < freezeTime)
        {
            time += Time.deltaTime;
            _playerFrozen = true;
            plane1Ignore = true;
            plane2Ignore = true;
            plane3Ignore = true;
            yield return null;
        }
        //Turn back to the starting position.
        if (time > 0)
        {
            time -= Time.deltaTime;
            plane1Ignore = true;
            plane2Ignore = false;
            plane3Ignore = true;
            playerController2D.whatIsGround = LayerMask.GetMask("Plane 2");
            sprite.sortingLayerName = Plane2SortingLayer;
            _playerFrozen = false;
            Debug.Log("Number of calls");
            yield return null;
        }
    }

    public IEnumerator Plane3Delay()
    {
        float time = 0;

        while (time < freezeTime)
        {
            time += Time.deltaTime;
            _playerFrozen = true;
            plane1Ignore = true;
            plane2Ignore = true;
            plane3Ignore = true;
            yield return null;
        }
        //Turn back to the starting position.
        if (time > 0)
        {
            time -= Time.deltaTime;
            plane1Ignore = true;
            plane2Ignore = true;
            plane3Ignore = false;
            playerController2D.whatIsGround = LayerMask.GetMask("Plane 3");
            sprite.sortingLayerName = Plane3SortingLayer;
            _playerFrozen = false;
            Debug.Log("Number of calls");
            yield return null;
        }
    }

}

