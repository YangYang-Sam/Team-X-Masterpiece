using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {

    [SerializeField]
    private GameObject[] _plane;
    public int currPlaneID;
        
    [SerializeField]
    private float _rotationDuration = 1.0f;
    [SerializeField]
    private float _planeMoveDuration = 1.0f;
    public Quaternion initialRotation = Quaternion.Euler(0, 0, 0);
    public Quaternion targetRotation = Quaternion.Euler(0, 0, 90);

    public Vector3 initialPosition;
    public Vector3 targetPosition;

    public bool leverPulled = false;
    public bool portal1Entered = false;
    public bool portal2Entered = false;
    public bool portal3Entered = false;

    [SerializeField]
    private Vector3 _plane1Pos;
    [SerializeField]
    private Vector3 _plane2Pos;
    [SerializeField]
    private Vector3 _plane3Pos;

    public float alpha = 0.1f;

    [SerializeField]
    Material material;

    Color color;

    // Use this for initialization
    void Start ()
    {
        _plane[0].transform.position = _plane1Pos;
        _plane[1].transform.position = _plane2Pos;
        _plane[2].transform.position = _plane3Pos;

        color = material.GetColor("_Color");

        //setAlpha(alpha);
    }
	
	void FixedUpdate ()
    {
        color.a = alpha;
        material.SetColor("_Color", color);

        if (leverPulled == true)
        {
            //print(_planeToRotate1.transform.rotation.eulerAngles.z);
            //initialPosition = _plane[currPlaneID].transform.position;
            StartCoroutine(RotateOverTime(initialRotation, targetRotation, _rotationDuration));
        }
        if (portal1Entered == true)
        {
            //print(_planeToRotate1.transform.rotation.eulerAngles.z);
            //initialPosition = _plane[currPlaneID].transform.position;
            StartCoroutine(MoveOverTime(initialPosition, targetPosition, _planeMoveDuration));
            currPlaneID = 0;
            initialPosition = _plane[currPlaneID].transform.position;
            portal1Entered = false;
}
        if (portal2Entered == true)
        {
            //print(_planeToRotate1.transform.rotation.eulerAngles.z);
            //initialPosition = _plane[currPlaneID].transform.position;
            StartCoroutine(MoveOverTime(initialPosition, targetPosition, _planeMoveDuration));
            currPlaneID = 1;
            initialPosition = _plane[currPlaneID].transform.position;
            portal2Entered = false;
        }
        if (portal3Entered == true)
        {
            //print(_planeToRotate1.transform.rotation.eulerAngles.z);
            //initialPosition = _plane[currPlaneID].transform.position;
            StartCoroutine(MoveOverTime(initialPosition, targetPosition, _planeMoveDuration));
            currPlaneID = 2;
            initialPosition = _plane[currPlaneID].transform.position;
            portal3Entered = false;
        }
    }

    private IEnumerator RotateOverTime(Quaternion initialRotation, Quaternion targetRotation, float _rotationDuration)
    {
        if (_rotationDuration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + _rotationDuration;
            _plane[1].transform.rotation = initialRotation;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / _rotationDuration;
                // progress will equal 0 at startTime, 1 at endTime.
                _plane[1].transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, progress);
                yield return null;
            }
        }
        leverPulled = false;
        _plane[1].transform.rotation = targetRotation;
    }

    private IEnumerator MoveOverTime(Vector3 initialPosition, Vector3 targetPosition, float _planeMoveDuration)
    {
        if (_planeMoveDuration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + _planeMoveDuration;
            _plane[currPlaneID].transform.position = initialPosition;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / _planeMoveDuration;
                // progress will equal 0 at startTime, 1 at endTime.
                _plane[currPlaneID].transform.position = Vector3.Lerp(initialPosition, targetPosition, progress);
                yield return null;
            }
        }

        _plane[currPlaneID].transform.position = targetPosition;
    }

    //private IEnumerator FadeIn()
    //{
    //    Color tmp = _spriteRenderer.GetComponent<SpriteRenderer>().color;
    //    tmp.a = 0f;
    //    _spriteRenderer.GetComponent<SpriteRenderer>().color = tmp;
    //    float _progress = 0.0f;

    //    while (_progress < 1)
    //    {
    //        Color _tmpColor = _spriteRenderer.GetComponent<SpriteRenderer>().color;
    //        GetComponent<SpriteRenderer>().color = new Color(_tmpColor.r, _tmpColor.g, _tmpColor.b, Mathf.Lerp(tmp.a, 255, _progress)); //startAlpha = 0 <-- value is in tmp.a
    //        _progress += Time.deltaTime * 1.5f;
    //        yield return null;
    //    }
    //}

    //public void setAlpha(float alpha)
    //{
    //    SpriteRenderer[] children = GetComponentsInChildren<SpriteRenderer>();
    //    Color newColor;

    //    foreach (SpriteRenderer child in children)
    //    {
    //        newColor = child.color;
    //        newColor.a = alpha;
    //        child.color = newColor;
    //    }
    //}
}
