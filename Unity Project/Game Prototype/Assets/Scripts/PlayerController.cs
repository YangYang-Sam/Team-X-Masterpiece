using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpforce;
    private float moveInput;

    private Rigidbody2D m_Rigidbody;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private void Start()
    {

        //Fetch the Rigidbody component from the GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();

        //Ignore the collisions between layer 8 (player) and layer 8 (custom layer you set in Inspector window)
        Physics2D.IgnoreLayerCollision(8, 10);
    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        m_Rigidbody.velocity = new Vector2(moveInput * speed, m_Rigidbody.velocity.y);

    }

}
