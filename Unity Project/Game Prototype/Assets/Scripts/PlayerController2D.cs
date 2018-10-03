using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private float _speed;
    [SerializeField]
    private float _speedValue;
    [SerializeField]
    private float jumpforce;
    [SerializeField]
    private float _veilJumpForce;
    private float horizontalMove;

    private Rigidbody2D _playerRigidbody;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int _canJump;
    private int _canVeilJump;
    [SerializeField]
    private int _canJumpValue;
    [SerializeField]
    private int _canVeilJumpValue;
    [SerializeField]
    private float _veilJumpWidthScale;
    private float _originalWidthScale;

    private SpriteRenderer _spriteRenderer;
    //private BoxCollider2D _BoxCollider2D;
    //private CircleCollider2D _CircleCollider2D;

    //Vector2 and float to store original Box Collider size and Circle collider radius respectively.
    //private Vector2 _BoxColliderSize;
    //private float _CircleColliderRadius;

    //private Vector2 _spriteRendererSize;

    //private Vector2 _BoxColliderOffset;
    //private Vector2 _CircleColliderOffset;


    private void Start()
    {
        _speed = _speedValue;
        _canJump = _canJumpValue;
        _canVeilJump = _canVeilJumpValue;
        _originalWidthScale = transform.localScale.x;
        //Debug.Log(_originalWidthScale);

        //Fetch the Rigidbody component from the GameObject
        _playerRigidbody = GetComponent<Rigidbody2D>();
        //Fetch the SpriteRenderer component from the GameObject
        _spriteRenderer = GetComponent<SpriteRenderer>();

        //Debug.Log(whatIsGround);

        FindObjectOfType<AudioManager>().Play("MenuLoop");

        ////gets box collider
        //_BoxCollider2D = GetComponent<BoxCollider2D>();
        ////stores boxcollider size and offset
        //_BoxColliderSize = _BoxCollider2D.size;
        //_BoxColliderOffset = _BoxCollider2D.offset;
        //Debug.Log(_BoxCollider2D.size);
        ////stores circlecollider radius and offset
        //_CircleCollider2D = GetComponent<CircleCollider2D>();
        //_CircleColliderRadius = _CircleCollider2D.radius;
        //_CircleColliderOffset = _CircleCollider2D.offset;
        //Debug.Log(_CircleCollider2D.radius);
        ////stores _spriteRenderer size and offset
        //_spriteRenderer = GetComponent<SpriteRenderer>();

        ////_BoxCollider2D.size = new Vector2(0.05f, 0.3f);
        //Debug.Log(_BoxColliderSize);
        ////_CircleCollider2D.radius = 0.1f;
        //Debug.Log(_CircleColliderRadius);

        //UpdateColliderSize();


    }

    private void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        _playerRigidbody.velocity = new Vector2(horizontalMove * _speed, _playerRigidbody.velocity.y);

        if (facingRight == false && horizontalMove > 0)
        {
            facingRight = !facingRight;
            _spriteRenderer.flipX = false;
        }
        else if (facingRight == true && horizontalMove < 0)
        {
            facingRight = !facingRight;
            _spriteRenderer.flipX = true;
        }

    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        horizontalMove = Input.GetAxis("Horizontal");

        if (isGrounded == true)
        {
            _canJump = _canJumpValue;
            _canVeilJump = _canVeilJumpValue;
            _speed = _speedValue;
        }

        if (isGrounded == false && _playerRigidbody.velocity.y <= 0)
        {
            ResetVeilJump();
        }

        if (Input.GetButtonDown("Jump") && _canJump > 0)
        {
            Jump();
        }

        else if (Input.GetButtonDown("Veil Jump") && _canVeilJump > 0)
        {
            VeilJump();
        }

    }

    private void Jump()
    {
        _playerRigidbody.gravityScale = 3;
        _playerRigidbody.velocity = Vector2.up * jumpforce;
        FindObjectOfType<AudioManager>().Play("PlayerJump");
        ResetVeilJump();
        _canJump--;
        _canVeilJump--;
    }

    private void VeilJump()
    {
        _playerRigidbody.gravityScale = 25;
        //set x velocity to 0 and jump with veiljump property.
        _playerRigidbody.velocity = new Vector2(0, 1 * _veilJumpForce);
        FindObjectOfType<AudioManager>().Play("VeilJump");
        _speed = 0;
        transform.localScale = new Vector3(transform.localScale.x * _veilJumpWidthScale, transform.localScale.y, transform.localScale.z);
        _canVeilJump--;
        _canJump --;
    }

    private void ResetVeilJump()
    {
        _playerRigidbody.gravityScale = 3;
        transform.localScale = new Vector3(_originalWidthScale, transform.localScale.y, transform.localScale.z);
        _speed = _speedValue;
        _playerRigidbody.velocity = new Vector2(horizontalMove * _speed, _playerRigidbody.velocity.y);
    }


    private void UpdateColliderSize()
    {

        //_BoxCollider2D.size = _spriteRenderer.sprite.bounds.size;
        //_BoxCollider2D.offset = new Vector2(0, 0);
        //_CircleCollider2D.radius = _spriteRenderer.sprite.bounds.size.x * 0.3317394f;

        //Debug.Log(_spriteRenderer.sprite.bounds.size.x + " = sprite x value");
    }

}