using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject[] _spawnPoint;
    [SerializeField]
    private float _spawnTime;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayerDamage(int SpawnPoint)
    {
        _player.gameObject.SetActive(false);

        StartCoroutine(SpawnDelay(SpawnPoint));
    }

    public IEnumerator SpawnDelay(int SpawnPoint)
    {

        float time = 0;

        while (time < _spawnTime)
        {
            time += Time.deltaTime;
            yield return null;
        }
        //spawn player
        if (time > 0)
        {
            time -= Time.deltaTime;
            SpawnPlayer(SpawnPoint);
            yield return null;
        }


    }

    private void SpawnPlayer(int SpawnPoint)
    {
        if (SpawnPoint == 1)
        {
            Debug.Log("SpawnPoint 1");
            _player.gameObject.transform.position = _spawnPoint[0].transform.position;
        }
        else if (SpawnPoint == 2)
        {
            Debug.Log("SpawnPoint 2");
            _player.gameObject.transform.position = _spawnPoint[1].transform.position;
        }
        else if (SpawnPoint == 3)
        {
            Debug.Log("SpawnPoint 3");
            _player.gameObject.transform.position = _spawnPoint[2].transform.position;
        }
        else if (SpawnPoint == 4)
        {
            Debug.Log("SpawnPoint 4");
            _player.gameObject.transform.position = _spawnPoint[3].transform.position;
        }
        _player.gameObject.SetActive(true);
        Debug.Log("Player spawned");
    }
}
