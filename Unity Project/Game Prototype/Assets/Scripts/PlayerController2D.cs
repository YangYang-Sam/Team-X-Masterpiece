using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour {

    public float speed;
    public float jumpforce;
    private float moveInput;

    private Rigidbody2D _playerRigidbody;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

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
        extraJumps = extraJumpsValue;

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
        moveInput = Input.GetAxis("Horizontal");
        _playerRigidbody.velocity = new Vector2(moveInput * speed, _playerRigidbody.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }

    private void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if(Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            _playerRigidbody.velocity = Vector2.up * jumpforce;
            extraJumps--;
        } else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            _playerRigidbody.velocity = Vector2.up * jumpforce;
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
