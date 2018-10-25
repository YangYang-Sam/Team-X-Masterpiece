using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _planesParent;
    [SerializeField]
    public GameObject[] _plane;

    [SerializeField]
    private Vector3 _plane1Pos;
    [SerializeField]
    private Vector3 _plane2Pos;
    [SerializeField]
    private Vector3 _plane3Pos;

    [SerializeField]
    private float _planeMoveDuration = 1.0f;

    [SerializeField]
    private float _rotationDuration = 1.0f;
    [SerializeField]
    private AkEvent rotationSound;

    [SerializeField]
    private Transform initialRotation;
    [SerializeField]
    private Transform targetRotation;

    [SerializeField]
    private float _colorChangeDuration = 1.0f;

    public Vector3 initialPosition;
    public Vector3 targetPositionIn;

    public bool leverPulled = false;
    public bool portal1Entered = false;
    public bool portal2Entered = false;
    public bool portal3Entered = false;

    [Range(0f, 1f)]
    public float[] alpha;

    private float plane1Alpha;
    private float plane2Alpha;
    private float plane3Alpha;

    [SerializeField]
    private Material[] _planeMaterials;

    [SerializeField]
    private Color[] _planeColor;

    void Start()
    {
        _plane[0].transform.position = _plane1Pos;
        _plane[1].transform.position = _plane2Pos;
        _plane[2].transform.position = _plane3Pos;
    }

    void FixedUpdate()
    {
        //_planeColor[currPlaneID].a = alpha[currPlaneID];
        //_planeColor[prevPlaneID].a = alpha[prevPlaneID];
        _planeColor[0].a = alpha[0];
        _planeColor[1].a = alpha[1];
        _planeColor[2].a = alpha[2];
        _planeMaterials[0].SetColor("_Color", _planeColor[0]);
        _planeMaterials[1].SetColor("_Color", _planeColor[1]);
        _planeMaterials[2].SetColor("_Color", _planeColor[2]);

        if (leverPulled == true)
        {
            //print(_planeToRotate1.transform.rotation.eulerAngles.z);
            //initialPosition = _plane[currPlaneID].transform.position;
            PlaneRotationSound();
            StartCoroutine(RotatePlane(initialRotation, targetRotation, _rotationDuration));
            leverPulled = false;
        }
        if (portal1Entered == true)
        {
            targetPositionIn = new Vector3(0, 0, 0);
            StartCoroutine(MovePlane(initialPosition, targetPositionIn, _planeMoveDuration));
            StartCoroutine(Fade(alpha[0], 1.0f, _colorChangeDuration, 0));
            StartCoroutine(Fade(alpha[1], 0.3f, _colorChangeDuration, 1));
            StartCoroutine(Fade(alpha[2], 0.1f, _colorChangeDuration, 2));
            portal1Entered = false;
        }
        if (portal2Entered == true)
        {
            targetPositionIn = new Vector3(0, 0, -10);
            StartCoroutine(MovePlane(initialPosition, targetPositionIn, _planeMoveDuration));
            StartCoroutine(Fade(alpha[0], 0.1f, _colorChangeDuration, 0));
            StartCoroutine(Fade(alpha[1], 1.0f, _colorChangeDuration, 1));
            StartCoroutine(Fade(alpha[2], 0.3f, _colorChangeDuration, 2));
            portal2Entered = false;
        }
        if (portal3Entered == true)
        {
            targetPositionIn = new Vector3(0, 0, -20);
            StartCoroutine(MovePlane(initialPosition, targetPositionIn, _planeMoveDuration));
            StartCoroutine(Fade(alpha[0], 0.1f, _colorChangeDuration, 0));
            StartCoroutine(Fade(alpha[1], 0.3f, _colorChangeDuration, 1));
            StartCoroutine(Fade(alpha[2], 1.0f, _colorChangeDuration, 2));
            portal3Entered = false;
        }
    }

    private IEnumerator RotatePlane(Transform initialRotation, Transform targetRotation, float _rotationDuration)
    {
        if (_rotationDuration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + _rotationDuration;
            //_plane[2].transform.rotation = initialRotation;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / _rotationDuration;
                // progress will equal 0 at startTime, 1 at endTime.
                _plane[2].transform.rotation = Quaternion.Slerp(initialRotation.rotation, targetRotation.rotation, progress);
                yield return null;
            }
        }
        //initialRotation = initialRotation * targetRotation;
        _plane[2].transform.rotation = targetRotation.rotation;
        leverPulled = false;
    }

    private IEnumerator MovePlane(Vector3 initialPosition, Vector3 targetPosition, float _planeMoveDuration)
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

    private IEnumerator Fade(float initialAlpha, float targetAlpha, float _colorChangeDuration, int planeID)
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
                alpha[planeID] = Mathf.Lerp(alpha[planeID], targetAlpha, progress);
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
