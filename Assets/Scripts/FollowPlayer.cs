
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;


    void Start()
    {
        offset = transform.position - target.position;
    }
    void LateUpdate()
    {
        

        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothSpeed);
        transform.position = smoothedPos;

        transform.rotation = target.rotation;

       
    }
}
