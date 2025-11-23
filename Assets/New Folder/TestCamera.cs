using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        transform.position = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            offset.z   // камера всегда на -10
        );
    }
}
