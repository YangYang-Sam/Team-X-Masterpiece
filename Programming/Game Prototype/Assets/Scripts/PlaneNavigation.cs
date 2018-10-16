using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneNavigation : MonoBehaviour {

    //Access playerController class
    [SerializeField]
    private GameObject _playerPrefab;

    private PlayerController2D _playerController2D;

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
    //private SpriteRenderer _playerController2D._spriteRenderer;

    private int PlayerCollisionLayer;
    private int Plane1CollisionLayer;
    private int Plane2CollisionLayer;
    private int Plane3CollisionLayer;

    [SerializeField]
    public bool _playerFrozen;
    [SerializeField]
    public float freezeTime;
    //how long should we freeze for.

    //variable to store the current plane the player is on
    public int _currentPlane = 1;

    [SerializeField]
    public GameObject _plane1Spawn;
    [SerializeField]
    public GameObject _plane2Spawn;
    [SerializeField]
    public GameObject _plane3Spawn;

    // Use this for initialization
    void Start ()
    {
        //Plane1.SetActive(true);
        //Plane2.SetActive(false);
        //Plane3.SetActive(false);


        //Plane3.transform.localScale = Vector3.zero;

        _currentPlane = 1;

        _playerController2D = _playerPrefab.GetComponent<PlayerController2D>(); 
        _playerController2D.whatIsGround = LayerMask.GetMask("Plane 1");
        //sets collision layers as layer numbers
        PlayerCollisionLayer = LayerMask.NameToLayer("Player");
        Plane1CollisionLayer = LayerMask.NameToLayer("Plane 1");
        Plane2CollisionLayer = LayerMask.NameToLayer("Plane 2");
        Plane3CollisionLayer = LayerMask.NameToLayer("Plane 3");

        //sets sprite variable to SpriteRenderer component
        //_playerController2D._spriteRenderer = _playerController2D.GetComponent<SpriteRenderer>();

        if (_playerController2D._spriteRenderer)
        {
            _playerController2D._spriteRenderer.sortingOrder = sortingOrder;
            _playerController2D._spriteRenderer.sortingLayerName = Plane1SortingLayer;
            _playerController2D._spriteRenderer.sortingOrder = 1;
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
    //private void OnTriggerStay2D(Collider2D other)

    //{
    //    //switch to correct layer based on portal name
    //    if (other.name == "Plane 2 Portal" && Input.GetButtonDown("Interact"))
    //    {
    //        Plane2Selector();
    //    }

    //    else if (other.name == "Plane 3 Portal" && Input.GetButtonDown("Interact"))
    //    {
    //        Plane3Selector();
    //    }

    //    else if (other.name == "Plane 1 Portal" && Input.GetButtonDown("Interact"))
    //    {
    //        Plane1Selector();
    //    }

    //    if (other.name == "Lever" && Input.GetButtonDown("Interact"))
    //    {
    //        RotatePlane();
    //    }

    //}

    public void Plane1Selector()
    {
        //Plane1.SetActive(true);
        //Plane2.SetActive(false);
        //Plane3.SetActive(false);

        //Plane1.transform.localScale = Vector3.one;
        //Plane2.transform.localScale = Vector3.zero;
        //Plane3.transform.localScale = Vector3.zero;

        StartCoroutine(Plane1Delay());
        //Plane3.GetComponent<Animator>().Play("Plane3_Out");
        //Plane2.GetComponent<Animator>().Play("Plane2_Out_Middle");
        //Plane1.GetComponent<Animator>().Play("Plane1_In_From3");

        //turn on/off collisions for appropriate layer
        //plane1Ignore = false;
        //plane2Ignore = true;
        //plane3Ignore = true;
        FindObjectOfType<AudioManager>().Play("PortalEntry");

        _playerController2D.whatIsGround = LayerMask.GetMask("Plane 1");

        //Make player sprite render on correct layer
        _playerController2D._spriteRenderer.sortingLayerName = Plane1SortingLayer;

        _currentPlane = 1;
    }

    public void Plane2Selector()
    {
        //Plane1.SetActive(false);
        //Plane2.SetActive(true);
        //Plane3.SetActive(false);
        //Plane1.transform.localScale = Vector3.zero;
        //Plane2.transform.localScale = Vector3.one;
        //Plane3.transform.localScale = Vector3.zero;

        StartCoroutine(Plane2Delay());
        //Plane1.GetComponent<Animator>().Play("Plane1_Out");
        //Plane2.GetComponent<Animator>().Play("Plane2_In");
        //Plane3.GetComponent<Animator>().Play("Plane3_In_BG");
        //plane1Ignore = true;
        //plane2Ignore = false;
        //plane3Ignore = true;
        FindObjectOfType<AudioManager>().Play("PortalEntry");

        _playerController2D.whatIsGround = LayerMask.GetMask("Plane 2");

        //Make player sprite render on correct layer
        _playerController2D._spriteRenderer.sortingLayerName = Plane2SortingLayer;

        _currentPlane = 2;
    }

    public void Plane3Selector()
    {
        //Plane1.SetActive(false);
        //Plane2.SetActive(false);
        //Plane3.SetActive(true);

        //Plane1.transform.localScale = Vector3.zero;
        //Plane2.transform.localScale = Vector3.zero;
        //Plane3.transform.localScale = Vector3.one;

        StartCoroutine(Plane3Delay());
        //Plane2.GetComponent<Animator>().Play("Plane2_Out");
        //Plane3.GetComponent<Animator>().Play("Plane3_In");
        //plane1Ignore = true;
        //plane2Ignore = true;
        //plane3Ignore = false;
        FindObjectOfType<AudioManager>().Play("PortalEntry");

        _playerController2D.whatIsGround = LayerMask.GetMask("Plane 3");

        //Make player sprite render on correct layer
        _playerController2D._spriteRenderer.sortingLayerName = Plane3SortingLayer;
        _currentPlane = 3;
    }

    public IEnumerator FreezePlayer()
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
            _playerController2D.whatIsGround = LayerMask.GetMask("Plane 2");
            _playerController2D._spriteRenderer.sortingLayerName = Plane2SortingLayer;
            _playerFrozen = false;
            _playerController2D._playerRigidbody.gravityScale = _playerController2D._defaultGravity;
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
            _playerController2D.whatIsGround = LayerMask.GetMask("Plane 1");
            _playerController2D._spriteRenderer.sortingLayerName = Plane1SortingLayer;
            _playerFrozen = false;
            _playerController2D._playerRigidbody.gravityScale = _playerController2D._defaultGravity;
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
            _playerController2D.whatIsGround = LayerMask.GetMask("Plane 2");
            _playerController2D._spriteRenderer.sortingLayerName = Plane2SortingLayer;
            _playerFrozen = false;
            _playerController2D._playerRigidbody.gravityScale = _playerController2D._defaultGravity;
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
            _playerController2D.whatIsGround = LayerMask.GetMask("Plane 3");
            _playerController2D._spriteRenderer.sortingLayerName = Plane3SortingLayer;
            _playerFrozen = false;
            _playerController2D._playerRigidbody.gravityScale = _playerController2D._defaultGravity;
            Debug.Log("Number of calls");
            yield return null;
        }
    }

    public void RotatePlane()
    {
        Debug.Log("Lever Pulled");
        //Plane2.transform.rotation = 180;
    }
}

