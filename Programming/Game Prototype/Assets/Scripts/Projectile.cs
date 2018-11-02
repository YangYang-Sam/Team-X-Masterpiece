using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float _speed = 10.0f;

    //private PlayerController2D _playerController2D;
    private SpawnManager _spawnManager;

    // Use this for initialization
    void Start ()
    {
        _spawnManager = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnManager>();

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
            _spawnManager.Damage(1);
        }

        Destroy(this.gameObject);
    }

}
