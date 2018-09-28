using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpforce;
    [SerializeField]
    private float _veilJumpForce;
    private float moveInput;

    private Rigidbody2D _playerRigidbody;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int _extraJumps;
    private int _veilJumps;
    [SerializeField]
    private int _extraJumpsValue;
    [SerializeField]
    private int _veilJumpsValue;
    [SerializeField]
    private float _veilJumpWidthScale;
    private float _originalWidthScale;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _BoxCollider2D;
    private CircleCollider2D _CircleCollider2D;

    //Vector2 and float to store original Box Collider size and Circle collider radius respectively.
    private Vector2 _BoxColliderSize;
    private float _CircleColliderRadius;

    private Vector2 _spriteRendererSize;
    [SerializeField]
    private float _scaleFactor;

    private Vector2 _BoxColliderOffset;
    private Vector2 _CircleColliderOffset;


    private void Start()
    {
        _extraJumps = _extraJumpsValue;
        _veilJumps = _veilJumpsValue;
        _originalWidthScale = transform.localScale.x;
        Debug.Log(_originalWidthScale);

        //Fetch the Rigidbody component from the GameObject
        _playerRigidbody = GetComponent<Rigidbody2D>();

        Debug.Log(whatIsGround);


        //gets box collider
        _BoxCollider2D = GetComponent<BoxCollider2D>();
        //stores boxcollider size and offset
        _BoxColliderSize = _BoxCollider2D.size;
        _BoxColliderOffset = _BoxCollider2D.offset;
        Debug.Log(_BoxCollider2D.size);
        //stores circlecollider radius and offset
        _CircleCollider2D = GetComponent<CircleCollider2D>();
        _CircleColliderRadius = _CircleCollider2D.radius;
        _CircleColliderOffset = _CircleCollider2D.offset;
        Debug.Log(_CircleCollider2D.radius);
        //stores _spriteRenderer size and offset
        _spriteRenderer = GetComponent<SpriteRenderer>();

        //_BoxCollider2D.size = new Vector2(0.05f, 0.3f);
        Debug.Log(_BoxColliderSize);
        //_CircleCollider2D.radius = 0.1f;
        Debug.Log(_CircleColliderRadius);

        UpdateColliderSize();


    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }

    private void Update()
    {

        moveInput = Input.GetAxis("Horizontal");

        if (isGrounded == true)
        {
            _extraJumps = _extraJumpsValue;
            _veilJumps = _veilJumpsValue;
            //transform.localScale = new Vector3(_originalWidthScale, transform.localScale.y, transform.localScale.z);
            _playerRigidbody.velocity = new Vector2(moveInput * speed, _playerRigidbody.velocity.y);

        }

        if (isGrounded == false && _playerRigidbody.velocity.y <= 0)
        {
            _playerRigidbody.gravityScale = 3;
            transform.localScale = new Vector3(_originalWidthScale, transform.localScale.y, transform.localScale.z);
            _playerRigidbody.velocity = new Vector2(moveInput * speed, _playerRigidbody.velocity.y);

        }

        if (Input.GetButtonDown("Jump"))
        {
            if (_extraJumps > 0)
            {
                _playerRigidbody.gravityScale = 3;
                _playerRigidbody.velocity = Vector2.up * jumpforce;
                _extraJumps--;
            }
            else if (_extraJumps == 0 && isGrounded == true)
            {
                _playerRigidbody.gravityScale = 3;
                _playerRigidbody.velocity = Vector2.up * jumpforce;
            }

        }

        else if (Input.GetButtonDown("Veil Jump"))
        {
            Debug.Log("Veil Jump");
            if (_veilJumps > 0)
            {
                _playerRigidbody.gravityScale = 25;
                //set x velocity to 0 and jump with veiljump property.
                _playerRigidbody.velocity = new Vector2(0, 1 * _veilJumpForce);
                transform.localScale = new Vector3(transform.localScale.x * _veilJumpWidthScale, transform.localScale.y, transform.localScale.z);
                _veilJumps--;

            }
            else if (_veilJumps == 0 && isGrounded == true)
            {
                _playerRigidbody.gravityScale = 25;
                //set x velocity to 0 and jump with veiljump property.
                _playerRigidbody.velocity = new Vector2(0, 1 * _veilJumpForce);
                Debug.Log(transform.localScale + "original scale");
                transform.localScale = new Vector3(transform.localScale.x * _veilJumpWidthScale, transform.localScale.y, transform.localScale.z);
                Debug.Log(transform.localScale + "new scale");
                _veilJumps--;
            }
        }

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void UpdateColliderSize()
    {

        _BoxCollider2D.size = _spriteRenderer.sprite.bounds.size;
        _BoxCollider2D.offset = new Vector2(0, 0);
        _CircleCollider2D.radius = _spriteRenderer.sprite.bounds.size.x * 0.3317394f;

        Debug.Log(_spriteRenderer.sprite.bounds.size.x + " = sprite x value");
    }

}