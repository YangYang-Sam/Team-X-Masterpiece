using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyAI : MonoBehaviour {

    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private float shootDelay;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Shoot(shootDelay));
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private IEnumerator Shoot(float shootDelay)
    {
        while (_projectilePrefab != null)
        {
            Instantiate(_projectilePrefab, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity, transform);
            yield return new WaitForSeconds(shootDelay);
        }
    }

}
