using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotation : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        print(plane1.transform.rotation.eulerAngles.z);
        StartCoroutine(RotateOverTime(initialRotation, targetRotation, 1f / speed));
    }


    public GameObject plane1;
    public float speed = 0.5f;
    public Quaternion initialRotation = Quaternion.Euler(0, 0, 0);
    public Quaternion targetRotation = Quaternion.Euler(0, 0, 90);

    // Update is called once per frame

    IEnumerator RotateOverTime(Quaternion initialRotation, Quaternion targetRotation, float duration)
    {
        if (duration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
            plane1.transform.rotation = initialRotation;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;
                // progress will equal 0 at startTime, 1 at endTime.
                plane1.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, progress);
                yield return null;
            }
        }
        plane1.transform.rotation = targetRotation;
    }
}
