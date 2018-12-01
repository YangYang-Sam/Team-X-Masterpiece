using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemyAI : MonoBehaviour {

    [SerializeField]
    private GameObject audioManager;
    private WwiseAudioManager wwiseAudioManager;

    private bool chargingNoiseRunning = false;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float chargeSpeed;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float groundRayLength;
    [SerializeField]
    private float wallRayLength;
    [SerializeField]
    private float playerRayLength;

    public Transform wallDetection;
    public Transform groundDetection;
    public Transform playerDetection;

    private Vector2 originalPosition;

    private RaycastHit2D groundInfo;
    private RaycastHit2D wallInfo;
    private RaycastHit2D playerHit;

    private LayerMask planeMask;
    private LayerMask playerRayMask;

    private SpawnManager _spawnManager;

    [SerializeField]
    private Transform player;

    private void Start()
    {
        
        wwiseAudioManager = audioManager.GetComponent<WwiseAudioManager>();

        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        originalPosition = transform.localPosition;
    }

    private void FixedUpdate()
    {
        planeMask = LayerMask.GetMask("Plane 2");
        playerRayMask = LayerMask.GetMask("Player");
        wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, wallRayLength, planeMask);
        playerHit = Physics2D.Raycast(playerDetection.position, Vector2.right, playerRayLength, playerRayMask);

        if(transform.position.y < originalPosition.y - 1)
        {
            return;
        }

        if (playerHit.collider == true)
        {
            //Debug.Log("Player distance: " + Vector2.Distance(transform.position, playerHit.collider.transform.position));
        }
        if (wallInfo.collider == true)
        {
            //Debug.Log("Wall Hit " + wallInfo);
            //Debug.Log("Wall distance: " + Vector2.Distance(transform.position, wallInfo.collider.transform.position));
        }

        if (playerDetection.position.z == 0 && wallInfo.collider != null)
        {
            if (playerHit.collider == true && Vector2.Distance(transform.position, wallInfo.collider.transform.position) > Vector2.Distance(transform.position, playerHit.collider.transform.position))
            {
                if (Vector2.Distance(transform.position, wallInfo.collider.transform.position) >= 0.5f)
                {
                    animator.SetBool("IsCharging", true);
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), chargeSpeed * Time.deltaTime);

                    if (chargingNoiseRunning == false)
                    {
                        chargingNoiseRunning = true;
                        wwiseAudioManager.EnemyChargeSound();
                    }
                }
            }
            else
            {
                if (transform.position.x != originalPosition.x)
                {
                    animator.SetBool("IsCharging", true);
                    transform.position = Vector2.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);

                    if (chargingNoiseRunning == false)
                    {
                        chargingNoiseRunning = true;
                        wwiseAudioManager.EnemyChargeSound();
                    }

                    //stop charge animation if enemy has almost reached original position.
                    if (transform.position.x < originalPosition.x + 0.3f)
                    {
                        animator.SetBool("IsCharging", false);
                        chargingNoiseRunning = false;

                    }
                }
                else
                {
                    chargingNoiseRunning = false;
                    animator.SetBool("IsCharging", false);
                    return;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _spawnManager.PlayerDamage(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "YellowGooParent")
        {
            wwiseAudioManager.EnemyDeathSound();
            animator.SetBool("IsDead", true);
        }
    }
}
