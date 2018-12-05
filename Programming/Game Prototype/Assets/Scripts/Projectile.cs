using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float _speed = 6.0f;

    //private PlayerController2D _playerController2D;
    private WwiseAudioManager wwiseAudioManager;
    private SpawnManager _spawnManager;

    // Use this for initialization
    void Start ()
    {
        wwiseAudioManager = GameObject.Find("AudioManager").GetComponent<WwiseAudioManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _spawnManager.PlayerDamage(1);
            Destroy(this.gameObject);
        }

        else if (other.gameObject.name == "ShootingEnemy")
        {
            //Debug.Log("Hitting enemy");
            return;
        }
        else
        {
            wwiseAudioManager.EnemyBoulderSound();
            Destroy(this.gameObject);
        }

    }

}
