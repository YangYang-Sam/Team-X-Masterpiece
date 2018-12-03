using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneNavigation : MonoBehaviour {

    //Access playerController class
    [SerializeField]
    private GameObject _playerPrefab;

    private PlayerController2D _playerController2D;
    private PlaneMovement _planeMovement;
    private PlayerInteractions _playerInteractions;

    // sets player collisions based on layer/plane
    [SerializeField]
    private bool plane1Ignore = false;
    [SerializeField]
    private bool plane2Ignore = true;
    [SerializeField]
    private bool plane3Ignore = true;

    [SerializeField]
    private GameObject _planesParent;

    [SerializeField]
    public GameObject[] _plane1Platforms;

    [SerializeField]
    public GameObject[] _plane2Platforms;

    [SerializeField]
    public GameObject[] _plane3Platforms;

    public string Plane1SortingLayer = "Foreground";
    public string Plane2SortingLayer = "Middleground";
    public string Plane3SortingLayer = "Background";

    private int PlayerCollisionLayer;
    private int Plane1CollisionLayer;
    private int Plane2CollisionLayer;
    private int Plane3CollisionLayer;

    //variable to store the current plane the player is on
    public int _currentPlane = 1;

    // Use this for initialization
    void Start ()
    {
        _currentPlane = 1;

        _playerController2D = _playerPrefab.GetComponent<PlayerController2D>();
        _planeMovement = GetComponent<PlaneMovement>();
        _playerController2D.whatIsGround = LayerMask.GetMask("Plane 1");
        //sets collision layers as layer numbers
        PlayerCollisionLayer = LayerMask.NameToLayer("Player");
        Plane1CollisionLayer = LayerMask.NameToLayer("Plane 1");
        Plane2CollisionLayer = LayerMask.NameToLayer("Plane 2");
        Plane3CollisionLayer = LayerMask.NameToLayer("Plane 3");

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Sets the collisions between layer 8 (player) and platform layers
        Physics2D.IgnoreLayerCollision(PlayerCollisionLayer, Plane1CollisionLayer, plane1Ignore);
        Physics2D.IgnoreLayerCollision(PlayerCollisionLayer, Plane2CollisionLayer, plane2Ignore);
        Physics2D.IgnoreLayerCollision(PlayerCollisionLayer, Plane3CollisionLayer, plane3Ignore);
    }


    public IEnumerator Plane1Delay(Collider2D other)
    {
        float time = 0;

        while (time < _playerController2D.freezeTime)
        {
            time += Time.deltaTime;
            other.gameObject.transform.parent = null;
            _playerController2D._playerFrozen = true;
            plane1Ignore = true;
            plane2Ignore = true;
            plane3Ignore = true;
            PlatformParenting(_planeMovement._plane[0], other);
            yield return null;
        }
        //Set new layers/values according to new plane
        if (time > 0)
        {
            time -= Time.deltaTime;
            plane1Ignore = false;
            plane2Ignore = true;
            plane3Ignore = true;
            _playerController2D.whatIsGround = LayerMask.GetMask("Plane 1");
            _playerController2D._spriteRenderer.sortingLayerName = Plane1SortingLayer;
            _playerController2D._playerFrozen = false;
            _playerController2D._playerRigidbody.gravityScale = _playerController2D._defaultGravity;
            _currentPlane = 1;

            yield return null;
        }
    }

    public IEnumerator Plane2Delay(Collider2D other)
    {
        float time = 0;

        while (time < _playerController2D.freezeTime)
        {
            time += Time.deltaTime;
            other.gameObject.transform.parent = null;
            _playerController2D._playerFrozen = true;
            plane1Ignore = true;
            plane2Ignore = true;
            plane3Ignore = true;
            PlatformParenting(_planeMovement._plane[1], other);
            yield return null;
        }
        //Set new layers/values according to new plane
        if (time > 0)
        {
            time -= Time.deltaTime;
            plane1Ignore = true;
            plane2Ignore = false;
            plane3Ignore = true;
            _playerController2D.whatIsGround = LayerMask.GetMask("Plane 2");
            _playerController2D._spriteRenderer.sortingLayerName = Plane2SortingLayer;
            _playerController2D._playerFrozen = false;
            _playerController2D._playerRigidbody.gravityScale = _playerController2D._defaultGravity;
            _currentPlane = 2;

            yield return null;
        }
    }

    public IEnumerator Plane3Delay(Collider2D other)
    {
        float time = 0;

        while (time < _playerController2D.freezeTime)
        {
            time += Time.deltaTime;
            other.gameObject.transform.parent = null;
            _playerController2D._playerFrozen = true;
            plane1Ignore = true;
            plane2Ignore = true;
            plane3Ignore = true;
            PlatformParenting(_planeMovement._plane[2], other);
            yield return null;
        }
        //Set new layers/values according to new plane
        if (time > 0)
        {
            time -= Time.deltaTime;
            plane1Ignore = true;
            plane2Ignore = true;
            plane3Ignore = false;
            _playerController2D.whatIsGround = LayerMask.GetMask("Plane 3");
            _playerController2D._spriteRenderer.sortingLayerName = Plane3SortingLayer;
            _playerController2D._playerFrozen = false;
            _playerController2D._playerRigidbody.gravityScale = _playerController2D._defaultGravity;
            _currentPlane = 3;
            yield return null;
        }
    }

    public void PlatformParenting(GameObject plane, Collider2D other)
    {

        other.gameObject.transform.parent = plane.transform;

        other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0);

        if (other.transform.childCount == 0)
        {
            other.gameObject.transform.GetComponent<SpriteRenderer>().sortingLayerName = plane.gameObject.transform.GetComponent<SpriteRenderer>().sortingLayerName;
        }

        if (other.transform.childCount == 1)
        {
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = plane.gameObject.transform.GetComponent<SpriteRenderer>().sortingLayerName;
        }

        if (other.transform.childCount == 2)
        {
            other.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingLayerName = plane.gameObject.transform.GetComponent<SpriteRenderer>().sortingLayerName;
        }

        other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0.0f);
    }

}



