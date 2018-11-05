using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour {


    private SpawnManager _spawnManager;

    // Use this for initialization
    void Start ()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _spawnManager.PlayerDamage(3);
        }
        else if(other.gameObject.CompareTag("Platform Portal") == true)
        {
            Debug.Log("Platform collided with flames");
            Destroy(this.gameObject);
        }

    }
}
