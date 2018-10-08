using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    //Access playerController class
    private PlaneNavigation planeNavigation;

    //set variables to store speed etc and alter fields in inspector 
    private float _speed;
    [SerializeField]
    private float _speedValue;
    [SerializeField]
    private float jumpforce;
    [SerializeField]
    private float _veilJumpForce;
    private float horizontalMove;

    public Rigidbody2D _playerRigidbody;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int _defaultGravity = 3;
    private int _canJump;
    private int _canVeilJump;
    [SerializeField]
    private int _canJumpValue;
    [SerializeField]
    private int _canVeilJumpValue;
    [SerializeField]
    private float _veilJumpWidthScale;
    private Vector3 _veilJumpScale;

    private Vector3 _originalScale;

    private SpriteRenderer _spriteRenderer;




    private void Start()
    {
        planeNavigation = GetComponent<PlaneNavigation>();

        _speed = _speedValue;
        _canJump = _canJumpValue;
        _canVeilJump = _canVeilJumpValue;
        _originalScale = transform.localScale;
        _veilJumpScale = new Vector3(_originalScale.x * _veilJumpWidthScale, _originalScale.y, _originalScale.z);

        //Fetch the Rigidbody component from the GameObject
        _playerRigidbody = GetComponent<Rigidbody2D>();
        //Fetch the SpriteRenderer component from the GameObject
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //Play Main theme audio
        FindObjectOfType<AudioManager>().Play("MenuLoop");

    }

    private void FixedUpdate()
    {
        //Horizontal Movement
        if (planeNavigation._playerFrozen == false)
        {
            _playerRigidbody.velocity = new Vector2(horizontalMove * _speed, _playerRigidbody.velocity.y);
        }
        else if (planeNavigation._playerFrozen == true)
        {
            ResetVeilJump();
            _playerRigidbody.velocity = new Vector2(0, 0);
            _playerRigidbody.gravityScale = 0;
        }
        Flip();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        horizontalMove = Input.GetAxis("Horizontal");

        if (isGrounded == true)
        {
            _canJump = _canJumpValue;
            _canVeilJump = _canVeilJumpValue;

            if (Input.GetButtonDown("Temp Invincibility"))
            {
                TempInvincibility();
            }
            if (Input.GetButtonUp("Temp Invincibility"))
            {
                ResetVeilJump();
            }
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

    private void Flip()
    {
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

    private void Jump()
    {
        //set correct gravity and move player
        ResetVeilJump();
        _playerRigidbody.velocity = Vector2.up * jumpforce;
        //play cirrect sound depending on single or double jump
        if(_canJump == 2)
        {
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }
        else if (_canJump == 1)
        {
            FindObjectOfType<AudioManager>().Play("DoubleJump");
        }
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
        transform.localScale = _veilJumpScale;

        _canVeilJump--;
        _canJump --;
    }

    private void TempInvincibility()
    {
        _playerRigidbody.velocity = new Vector2(0, 0);
        FindObjectOfType<AudioManager>().Play("PortalEntry");
        _speed = 0;
        transform.localScale = _veilJumpScale;
    }

    //private void ResetInvincibility()
    //{

    //    _playerRigidbody.velocity = new Vector2(0, 0);
    //    //FindObjectOfType<AudioManager>().Play("VeilJump");
    //    _speed = 0;
    //    transform.localScale = new Vector3(transform.localScale.x * _veilJumpWidthScale, transform.localScale.y, transform.localScale.z);
    //}

    private void ResetVeilJump()
    {
        _playerRigidbody.gravityScale = _defaultGravity;
        transform.localScale = _originalScale;
        _speed = _speedValue;
        _playerRigidbody.velocity = new Vector2(horizontalMove * _speed, _playerRigidbody.velocity.y);
    }


    //private IEnumerator FreezePlayer()
    //{
    //    _playerFrozen = true;
    //    yield return new WaitForSeconds(1);
    //    _playerFrozen = false;
    //}
}