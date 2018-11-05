using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyAI : MonoBehaviour {

    [SerializeField]
    private GameObject _firePrefab;
    [SerializeField]
    private float fireDelay;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private IEnumerator Fire(float fireDelay)
    {
        while (_firePrefab != null)
        {
            Instantiate(_firePrefab, transform.position + new Vector3(-1.0f, 0, 0), Quaternion.identity, transform);
            yield return new WaitForSeconds(fireDelay);
        }
    }

}
