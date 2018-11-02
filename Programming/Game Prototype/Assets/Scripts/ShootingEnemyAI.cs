using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyAI : MonoBehaviour {

    [SerializeField]
    private GameObject _projectilePrefab;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Shoot());
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private IEnumerator Shoot()
    {
        while (_projectilePrefab != null)
        {
            Instantiate(_projectilePrefab, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity, transform);
            yield return new WaitForSeconds(5.0f);
        }
    }

}
