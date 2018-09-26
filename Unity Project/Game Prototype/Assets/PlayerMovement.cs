using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //access character controller class
    public CharacterController2D controller;

    //set run speed
    public float runspeed = 40f;
    //sets initial movement
    float horizontalMovement = 0f;
    //sets initial jump state to off
    bool jump = false;
    //sets initial crouch state to off
    bool crouch = false;
    //sets initial veil jump state to off
    bool veilJump = false;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _BoxCollider2D;
    private CircleCollider2D _CircleCollider2D;

    //Vector2 and float to store Box Collider size and Circle collider radius respectively.
    private Vector2 _BoxColliderSize;
    private float _CircleColliderSize;

    private Vector2 _spriteRendererSize;
    private float _scaleFactor;

    private Vector2 _BoxColliderOffset;
    private Vector2 _CircleColliderOffset;


    void Start()
    {
        //gets box collider
        _BoxCollider2D = GetComponent<BoxCollider2D>();
        //stores boxcollider size
        _BoxColliderSize = _BoxCollider2D.size;
        _BoxColliderOffset = _BoxCollider2D.offset;
        Debug.Log(_BoxCollider2D.size);

        _CircleCollider2D = GetComponent<CircleCollider2D>();
        _CircleColliderSize = _CircleCollider2D.radius;
        _CircleColliderOffset = _CircleCollider2D.offset;

        Debug.Log(_CircleCollider2D.radius);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRendererSize = _BoxCollider2D.size;
        _BoxColliderOffset = _BoxCollider2D.offset;

        //_BoxCollider2D.size = new Vector2(0.05f, 0.3f);
        Debug.Log(_BoxColliderSize);
        //_CircleCollider2D.radius = 0.1f;
        Debug.Log(_CircleColliderSize);

        UpdateColliderSize();
    }


    // Update is called once per frame
    void Update () {

        horizontalMovement = Input.GetAxisRaw("Horizontal") * runspeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Veil Jump"))
        {
            jump = true;
            transform.localScale = new Vector2(transform.localScale.x / 2, transform.localScale.y);
        }

        if (Input.GetButtonUp("Veil Jump"))
        {
            veilJump = false;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }

        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    private void FixedUpdate()
    {
        //Move character
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void UpdateColliderSize()
    {

        _BoxCollider2D.size = _spriteRenderer.sprite.bounds.size;
        _BoxCollider2D.offset = new Vector2(0, 0);
        _CircleCollider2D.radius = _spriteRenderer.sprite.bounds.size.x / 3;
        //_CircleCollider2D.offset = new Vector2(_CircleCollider2D.offset.x, _CircleCollider2D.offset.y + 0.5f * _CircleCollider2D.radius);

        //Vector3 spriteHalfSize = spriteRenderer.sprite.bounds.extents;
        //_CircleCollider2D.radius = spriteHalfSize.x > spriteHalfSize.y ? spriteHalfSize.x : spriteHalfSize.y;
        //lastSprite = spriteRenderer.sprite;

        //var _sprite = FindObjectOfType<SpriteRenderer>();
        //var _collider = FindObjectOfType<BoxCollider2D>();

        Debug.Log(_BoxCollider2D.size + "box collider size");

        //_BoxCollider2D.size = new Vector2(_spriteRenderer.sprite.bounds.size.x / transform.lossyScale.x,
        //                             _spriteRenderer.sprite.bounds.size.y / transform.lossyScale.y);
    }


}
