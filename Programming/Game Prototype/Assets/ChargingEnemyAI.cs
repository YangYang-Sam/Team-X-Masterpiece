using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemyAI : MonoBehaviour {

    public float speed;
    public float rayLength = 1.0f;

    private bool movingRight = true;

    public Transform wallDetection;
    public Transform groundDetection;

    private void Update()
    {
        LayerMask mask = LayerMask.GetMask("Plane 2");

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1.0f, mask);
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, 0.1f, mask);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        if (wallInfo.collider != null)
        {

            Debug.Log("Hit a wall");

            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
