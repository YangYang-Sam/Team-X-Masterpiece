﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour {


    private SpawnManager _spawnManager;
    private Vector3 initialScale;
    [SerializeField]
    private GameObject _flamesParent;
    [SerializeField]
    private Vector3 _flamesShrinkScale;
    [SerializeField]
    private float _flamesScaleDuration;



    // Use this for initialization
    void Start ()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        initialScale = _flamesParent.transform.localScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _spawnManager.PlayerDamage(3);

        }
        //block flames with platform and only detect non trigger collider on platform
        else if(other.isTrigger == false && other.CompareTag("Platform Portal"))
        {
            Debug.Log("Platform collided with flames");
            StartCoroutine(FlamesScale(_flamesParent.transform, initialScale, _flamesShrinkScale, _flamesScaleDuration));
        }
        else
        {
            return;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //unblock flames with platform and only detect non trigger collider on platform
        if (other.isTrigger == false && other.CompareTag("Platform Portal"))
        {
            Debug.Log("Platform exited flames");
            StartCoroutine(FlamesScale(_flamesParent.transform, _flamesShrinkScale, initialScale, _flamesScaleDuration));
        }

    }

    private IEnumerator FlamesScale(Transform thisTransform, Vector3 startScale, Vector3 endScale, float duration)
    {
        if(duration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;
                thisTransform.transform.localScale = Vector3.Lerp(startScale, endScale, progress);
                yield return null;
            }
        }
    }

}