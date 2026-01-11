using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera4 : MonoBehaviour
{
    public Transform target;
    private Vector2 deadZoneSize = new Vector2(2f, 1f);
    public float smoothSpeed = 2f;

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 diff = target.position - transform.position;

        if (Mathf.Abs(diff.x) > deadZoneSize.x)
            pos.x = Mathf.Lerp(pos.x, target.position.x, Time.deltaTime * smoothSpeed);

        if (Mathf.Abs(diff.y) > deadZoneSize.y)
            pos.y = Mathf.Lerp(pos.y, target.position.y, Time.deltaTime * smoothSpeed);

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}