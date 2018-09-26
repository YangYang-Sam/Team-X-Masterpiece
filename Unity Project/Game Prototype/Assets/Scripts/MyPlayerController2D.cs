using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController2D : MonoBehaviour {

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


    private void Start()
    {
        extraJumps = extraJumpsValue;

        //Fetch the Rigidbody component from the GameObject
        _playerRigidbody = GetComponent<Rigidbody2D>();

        Debug.Log(whatIsGround);
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

}
