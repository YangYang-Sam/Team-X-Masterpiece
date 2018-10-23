﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneNavigation : MonoBehaviour {

    //Access playerController class
    [SerializeField]
    private GameObject _playerPrefab;

    private PlayerController2D _playerController2D;
    private PlaneMovement _planeMovement;

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

    [SerializeField]
    public Material[] _planeMaterials;


    public const string Plane1SortingLayer = "Foreground";
    public const string Plane2SortingLayer = "Middleground";
    public const string Plane3SortingLayer = "Background";

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
        //Set new layers/values according to new plane
        if (time > 0)
        {
            PlatformParenting();
            time -= Time.deltaTime;
            plane1Ignore = false;
            plane2Ignore = true;
            plane3Ignore = true;
            _playerController2D.whatIsGround = LayerMask.GetMask("Plane 1");
            _playerController2D._spriteRenderer.sortingLayerName = Plane1SortingLayer;
            _playerFrozen = false;
            _playerController2D._playerRigidbody.gravityScale = _playerController2D._defaultGravity;
            _currentPlane = 1;
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
        //Set new layers/values according to new plane
        if (time > 0)
        {
            PlatformParenting();
            time -= Time.deltaTime;
            plane1Ignore = true;
            plane2Ignore = false;
            plane3Ignore = true;
            _playerController2D.whatIsGround = LayerMask.GetMask("Plane 2");
            _playerController2D._spriteRenderer.sortingLayerName = Plane2SortingLayer;
            _playerFrozen = false;
            _playerController2D._playerRigidbody.gravityScale = _playerController2D._defaultGravity;
            _currentPlane = 2;
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
        //Set new layers/values according to new plane
        if (time > 0)
        {
            PlatformParenting();
            time -= Time.deltaTime;
            plane1Ignore = true;
            plane2Ignore = true;
            plane3Ignore = false;
            _playerController2D.whatIsGround = LayerMask.GetMask("Plane 3");
            _playerController2D._spriteRenderer.sortingLayerName = Plane3SortingLayer;
            _playerFrozen = false;
            _playerController2D._playerRigidbody.gravityScale = _playerController2D._defaultGravity;
            _currentPlane = 3;
            Debug.Log("Number of calls");
            yield return null;
        }
    }

    public void PlatformParenting()
    {
        foreach (GameObject platform in _plane1Platforms)
        {
            platform.gameObject.transform.parent = _planesParent.transform;
        }

        foreach (GameObject platform in _plane2Platforms)
        {
            platform.gameObject.transform.parent = _planesParent.transform;
        }

        foreach (GameObject platform in _plane3Platforms)
        {
            platform.gameObject.transform.parent = _planesParent.transform;
        }
    }

    //public void PlatformMovement()
    //{
    //    //_plane1Platforms[0].transform.parent = null;
    //    _plane1Platforms[0].layer = 11;
    //    _plane1Platforms[0].GetComponent<SpriteRenderer>().material = _planeMaterials[1];
    //    _plane1Platforms[0].transform.parent = _planesParent.transform;
    //}


}



