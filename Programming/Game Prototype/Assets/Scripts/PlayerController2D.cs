using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField]
    private GameObject audioManager;
    private WwiseAudioManager wwiseAudioManager;

    private bool isFalling = false;

    [SerializeField]
    private Animation jumpAnim;
    [SerializeField]
    private Animator playerAnim;

    [SerializeField]
    private Animator animator;

    //Access playerController class
    [SerializeField]
    public GameObject _planeController;
    private PlaneNavigation _planeNavigation;

    //Access playerController class
    [SerializeField]
    public GameObject _dialogueManager;
    private DialogueManager _dialogueManagerScript;

    //[SerializeField]
    //private GameObject _playerPrefab;

    //set variables to store speed etc and alter fields in inspector 
    private float _speed;
    [SerializeField]
    private float _speedValue;
    [SerializeField]
    private float jumpforce;
    [SerializeField]
    private float _veilJumpForce;
    [SerializeField]
    public bool _playerFrozen;
    [SerializeField]
    public float freezeTime;

    private float horizontalMove;

    public Rigidbody2D _playerRigidbody;

    private bool facingRight = true;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int _defaultGravity;
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

    public SpriteRenderer _spriteRenderer;





    private void Start()
    {
        wwiseAudioManager = audioManager.GetComponent<WwiseAudioManager>();
        _planeNavigation = _planeController.GetComponent<PlaneNavigation>();
        _dialogueManagerScript = _dialogueManager.GetComponent<DialogueManager>();

        _speed = _speedValue;
        _canJump = _canJumpValue;
        _canVeilJump = _canVeilJumpValue;
        _originalScale = transform.localScale;
        _veilJumpScale = new Vector3(_originalScale.x * _veilJumpWidthScale, _originalScale.y, _originalScale.z);

        //Fetch the Rigidbody component from the GameObject
        _playerRigidbody = GetComponent<Rigidbody2D>();
        //Fetch the SpriteRenderer component from the GameObject
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        //if (playerAnim.IsInTransition(0) && playerAnim.GetNextAnimatorStateInfo(0).fullPathHash == playerAnim.)
        //{
        //    //Do reaction
        //}

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        horizontalMove = Input.GetAxisRaw("Horizontal") * _speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (isGrounded == true)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsVeilJumping", false);
            _canJump = _canJumpValue;
            _canVeilJump = _canVeilJumpValue;

            if (isFalling == true)
            {
                wwiseAudioManager.PlayerLandSound();
                isFalling = false;
            }
        }

        if (isGrounded == false && _playerRigidbody.velocity.y < 0)
        {
            isFalling = true;
        }

        if (Input.GetButtonDown("Jump") && _canJump > 0 && _playerFrozen == false && _dialogueManagerScript.dialogFreezePlayer == false)
        {
            Jump();
            animator.SetBool("IsJumping", true);
        }

        else if (Input.GetButtonDown("Jump") && isGrounded == false && _canVeilJump > 0 && _canJump < 1)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsVeilJumping", true);
            VeilJump();
        }

        //Horizontal Movement
        if (_playerFrozen == false && _dialogueManagerScript.dialogFreezePlayer == false)
        {
            _playerRigidbody.gravityScale = 5;
            _playerRigidbody.velocity = new Vector2(horizontalMove, _playerRigidbody.velocity.y);
        }
        else if (_playerFrozen == true)
        {
            //ResetVeilJump();
            _playerRigidbody.gravityScale = 0;
            _playerRigidbody.velocity = new Vector2(0, 0);
        }
        else if (_dialogueManagerScript.dialogFreezePlayer == true)
        {
            _playerRigidbody.velocity = new Vector2(0, _playerRigidbody.velocity.y);
        }

        Flip();
    }

    private void Update()
    {

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
        wwiseAudioManager.JumpSound();
        _playerRigidbody.velocity = Vector2.up * jumpforce;
        _canJump--;
    }

    private void VeilJump()
    {
        wwiseAudioManager.JumpSound();
        //_playerRigidbody.gravityScale = 25;
        //set x velocity to 0 and jump with veiljump property.
        //_playerRigidbody.velocity = new Vector2(0, 1 * _veilJumpForce);
        //_speed = 0;
        //transform.localScale = _veilJumpScale;
        _playerRigidbody.velocity = Vector2.up * jumpforce;
        _canVeilJump--;
    }

    private void ResetVeilJump()
    {
        _playerRigidbody.gravityScale = _defaultGravity;
        transform.localScale = _originalScale;
        _speed = _speedValue;
        _playerRigidbody.velocity = new Vector2(horizontalMove * _speed, _playerRigidbody.velocity.y);
    }

    private void PlayerSpawned()
    {
        animator.SetBool("IsSpawning", false);
    }
}