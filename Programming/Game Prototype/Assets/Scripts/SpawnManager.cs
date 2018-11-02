using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject _planeController;
    [SerializeField]
    private GameObject[] _spawnPoint;

    private PlaneNavigation _planeNavigation;

	// Use this for initialization
	void Start ()
    {
        _planeNavigation = _planeController.GetComponent<PlaneNavigation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Damage(int SpawnPoint)
    {
        gameObject.SetActive(false);
        SpawnPlayer(SpawnPoint);
    }

    private void SpawnPlayer(int SpawnPoint)
    {
        if (SpawnPoint == 1)
        {
            Debug.Log("SpawnPoint 1");
            gameObject.transform.position = _spawnPoint[0].transform.position;
        }
        else if (SpawnPoint == 2)
        {
            Debug.Log("SpawnPoint 2");
            gameObject.transform.position = _spawnPoint[1].transform.position;
        }
        else if (SpawnPoint == 3)
        {
            Debug.Log("SpawnPoint 3");
            gameObject.transform.position = _spawnPoint[2].transform.position;
        }
        gameObject.SetActive(true);
        Debug.Log("Player spawned");
    }
}
