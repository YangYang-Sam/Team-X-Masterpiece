using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float moveSpeed;

    private SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start ()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Plane 2"), LayerMask.NameToLayer("Plane 1"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Plane 2"), LayerMask.NameToLayer("Plane 2"), false);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Plane 2"), LayerMask.NameToLayer("Plane 3"), true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Patrol Marker")
        {
            moveSpeed *= -1;
            Debug.Log("collisions working");
            if (_spriteRenderer.flipX == true)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }
        }

        if (other.tag == "Player")
        {
            PlayerController2D player = other.GetComponent<PlayerController2D>();

            if (player != null)
            {
                player.Damage();
            }

            //EnemyExplosion();
        }

    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("Collided with: " + other.name);

    //    if (other.tag == "Player")
    //    {
    //        Player player = other.GetComponent<Player>();

    //        if (player != null)
    //        {
    //            player.Damage();
    //        }

    //        EnemyExplosion();
    //    }

    //    else if (other.tag == "Laser")
    //    {
    //        if (other.transform.parent != null)
    //        {
    //            Destroy(other.transform.parent.gameObject);
    //        }
    //        //destroy laser
    //        Destroy(other.gameObject);
    //        //destroy enemy
    //        EnemyExplosion();
    //    }

    //}
}
