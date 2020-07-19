using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        //Move camera to player in smooth transition.
        Vector3 targetCamPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPosition, smoothing * Time.deltaTime);
    }
}
