using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    //higher value due to being multiplied by time.deltaTime
    public float smoothSpeed;

    private Vector3 velocity = Vector3.zero;

    public Vector3 offset;

    public Vector3 minimumBoundary;

    public Vector3 maximumBoundary;

    private void LateUpdate()
    {
        //sets camera follow with target positions, movement smoothing and offset.
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;

        //clamp positions so camera stays within boundries of level
        transform.position = new Vector3
            (Mathf.Clamp(smoothedPosition.x, minimumBoundary.x, maximumBoundary.x),
        Mathf.Clamp(smoothedPosition.y, minimumBoundary.y, maximumBoundary.y), transform.position.z);

        //Vector3 finalPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        //transform.position = finalPosition;
    }

}
