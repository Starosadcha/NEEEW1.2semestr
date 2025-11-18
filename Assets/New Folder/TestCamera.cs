using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = target.position;
    }
}
