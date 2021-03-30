using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;

    public Transform target;

    public float speed;

    public float smoothTime = 0.3F;

    private Vector3 velocity = Vector3.zero;

    public bool follow = true;

    private void Start()
    {
        follow = true;
    }

    void Update()
    {

        if(follow)
            transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime);
    }
}
