using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField]
    private AkEvent rotationSound;
    [SerializeField]
    private GameObject _planesParent;
    [SerializeField]
    private GameObject[] _plane;
    public int currPlaneID;
    public int prevPlaneID;

    [SerializeField]
    private float _rotationDuration = 1.0f;
    [SerializeField]
    private float _planeMoveDuration = 1.0f;
    public Quaternion initialRotation = Quaternion.Euler(0, 0, 0);
    public Quaternion targetRotation = Quaternion.Euler(0, 0, 90);

    [SerializeField]
    private float _colorChangeDuration = 1.0f;

    public Vector3 initialPosition;
    public Vector3 targetPositionIn;

    public Vector3 targetPositionOut;

    public Color initialColorOut;
    public Color targetColorOut;

    public Color initialColorIn;
    public Color targetColorIn;

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

    [Range(0f, 1f)]
    public float[] alpha;

    [SerializeField]
    private Material[] _planeMat;
    //[SerializeField]
    //private Material _plane1Mat;
    //[SerializeField]
    //private Material _plane2Mat;
    //[SerializeField]
    //private Material _plane3Mat;

    [SerializeField]
    private Color[] _planeColor;
    //private Color _plane2Color;
    //private Color _plane3Color;

    // Use this for initialization
    void Start()
    {
        _plane[0].transform.position = _plane1Pos;
        _plane[1].transform.position = _plane2Pos;
        _plane[2].transform.position = _plane3Pos;

        //initialColor = _planeMat[currPlaneID].GetColor("_Color");
        //_planeColor[0] = initialColor;
        //_planeColor[1] = initialColor;
        //_planeColor[2] = initialColor;

        //setAlpha(alpha);
    }

    void FixedUpdate()
    {
        //_planeColor[currPlaneID].a = alpha[currPlaneID];
        //_planeColor[prevPlaneID].a = alpha[prevPlaneID];
        _planeColor[0].a = alpha[0];
        _planeColor[1].a = alpha[1];
        _planeColor[2].a = alpha[2];
        _planeMat[0].SetColor("_Color", _planeColor[0]);
        _planeMat[1].SetColor("_Color", _planeColor[1]);
        _planeMat[2].SetColor("_Color", _planeColor[2]);

        if (leverPulled == true)
        {
            //print(_planeToRotate1.transform.rotation.eulerAngles.z);
            //initialPosition = _plane[currPlaneID].transform.position;
            leverPulled = false;
            PlaneRotationSound();
            StartCoroutine(RotateOverTime(initialRotation, targetRotation, _rotationDuration));
        }
        if (portal1Entered == true)
        {
            targetPositionIn = new Vector3(0, 0, 0);
            //print(_planeToRotate1.transform.rotation.eulerAngles.z);
            //initialPosition = _plane[currPlaneID].transform.position;
            prevPlaneID = currPlaneID;
            currPlaneID = 0;
            initialColorIn = _planeMat[currPlaneID].GetColor("_Color");
            initialColorOut = _planeMat[prevPlaneID].GetColor("_Color");
            initialPosition = _plane[currPlaneID].transform.position;
            //targetPositionOut = _plane[prevPlaneID].transform.position;
            StartCoroutine(MoveOverTime(initialPosition, targetPositionIn, _planeMoveDuration));
            //StartCoroutine(MoveOutOverTime(initialPosition, targetPositionOut, _planeMoveDuration));
            StartCoroutine(FadeIn(initialColorIn, targetColorIn, _colorChangeDuration));
            StartCoroutine(FadeOut(initialColorOut, targetColorOut, _colorChangeDuration));
            portal1Entered = false;
        }
        if (portal2Entered == true)
        {
            targetPositionIn = new Vector3(0, 0, -10);
            //print(_planeToRotate1.transform.rotation.eulerAngles.z);
            //initialPosition = _plane[currPlaneID].transform.position;
            prevPlaneID = currPlaneID;
            currPlaneID = 1;
            initialColorIn = _planeMat[currPlaneID].GetColor("_Color");
            initialColorOut = _planeMat[prevPlaneID].GetColor("_Color");
            //initialPosition = _plane[currPlaneID].transform.position;
            //targetPositionOut = _plane[prevPlaneID].transform.position;
            StartCoroutine(MoveOverTime(initialPosition, targetPositionIn, _planeMoveDuration));
            //StartCoroutine(MoveOutOverTime(initialPosition, targetPositionOut, _planeMoveDuration));
            StartCoroutine(FadeIn(initialColorIn, targetColorIn, _colorChangeDuration));
            StartCoroutine(FadeOut(initialColorOut, targetColorOut, _colorChangeDuration));
            portal2Entered = false;
        }
        if (portal3Entered == true)
        {
            targetPositionIn = new Vector3(0, 0, -20);
            //print(_planeToRotate1.transform.rotation.eulerAngles.z);
            //initialPosition = _plane[currPlaneID].transform.position;
            prevPlaneID = currPlaneID;
            currPlaneID = 2;
            initialColorIn = _planeMat[currPlaneID].GetColor("_Color");
            initialColorOut = _planeMat[prevPlaneID].GetColor("_Color");
            initialPosition = _plane[currPlaneID].transform.position;
            //targetPositionOut = _plane[prevPlaneID].transform.position;
            StartCoroutine(MoveOverTime(initialPosition, targetPositionIn, _planeMoveDuration));
            //StartCoroutine(MoveOutOverTime(initialPosition, targetPositionOut, _planeMoveDuration));
            StartCoroutine(FadeIn(initialColorIn, targetColorIn, _colorChangeDuration));
            StartCoroutine(FadeOut(initialColorOut, targetColorOut, _colorChangeDuration));
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
            initialPosition = _planesParent.transform.position;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / _planeMoveDuration;
                // progress will equal 0 at startTime, 1 at endTime.
                _planesParent.transform.position = Vector3.Lerp(initialPosition, targetPosition, progress);
                yield return null;
            }
        }

        _planesParent.transform.position = targetPosition;
    }

    private IEnumerator MoveOutOverTime(Vector3 initialPosition, Vector3 targetPosition, float _planeMoveDuration)
    {
        if (_planeMoveDuration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + _planeMoveDuration;
            _plane[prevPlaneID].transform.position = initialPosition;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / _planeMoveDuration;
                // progress will equal 0 at startTime, 1 at endTime.
                _plane[prevPlaneID].transform.position = Vector3.Lerp(initialPosition, targetPosition, progress);
                yield return null;
            }
        }

        _plane[prevPlaneID].transform.position = targetPosition;
    }

    private IEnumerator FadeIn(Color initialColor, Color targetColor, float _colorChangeDuration)
    {
        if (_colorChangeDuration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + _colorChangeDuration;
            //_plane1Color.transform.position = initialPosition;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / _colorChangeDuration;
                // progress will equal 0 at startTime, 1 at endTime.
                alpha[currPlaneID] = Mathf.Lerp(0.3f, 1, progress);
                yield return null;
            }

        }

    }

    private IEnumerator FadeOut(Color initialColor, Color targetColor, float _colorChangeDuration)
    {
        if (_colorChangeDuration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + _colorChangeDuration;
            //_plane1Color.transform.position = initialPosition;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / _colorChangeDuration;
                // progress will equal 0 at startTime, 1 at endTime.
                alpha[prevPlaneID] = Mathf.Lerp(1, 0.3f, progress);
                yield return null;
            }

        }

    }

    private void PlaneRotationSound()
    {
        if (rotationSound != null)
        {
            rotationSound.HandleEvent(gameObject);
        }
    }

}
