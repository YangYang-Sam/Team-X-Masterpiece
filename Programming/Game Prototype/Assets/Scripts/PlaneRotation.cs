using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotation : MonoBehaviour {

    [SerializeField]
    private GameObject _planeToRotate;
    public float speed = 0.5f;
    public Quaternion initialRotation = Quaternion.Euler(0, 0, 0);
    public Quaternion targetRotation = Quaternion.Euler(0, 0, 90);

    public bool leverPulled = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	void FixedUpdate ()
    {
        if(leverPulled == true)
        {
            //print(_planeToRotate1.transform.rotation.eulerAngles.z);
            StartCoroutine(RotateOverTime(initialRotation, targetRotation, 1f / speed));
        }
    }

    IEnumerator RotateOverTime(Quaternion initialRotation, Quaternion targetRotation, float duration)
    {
        if (duration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
            _planeToRotate.transform.rotation = initialRotation;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;
                // progress will equal 0 at startTime, 1 at endTime.
                _planeToRotate.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, progress);
                yield return null;
            }
        }
        leverPulled = false;
        _planeToRotate.transform.rotation = targetRotation;
    }
}
