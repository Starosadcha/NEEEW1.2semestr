using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3 : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;
    private float lookAheadDistance = 2f;
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        Vector3 targetPos = transform.position + new Vector3(direction * lookAheadDistance, 0, -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
