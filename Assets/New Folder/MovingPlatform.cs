using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // начальная точка
    public Transform pointB; // конечная точка
    public float speed = 2f;

    private bool playerOn = false;
    private Vector3 target;

    void Start()
    {
        if (pointA == null || pointB == null)
        {
           
            enabled = false;
            return;
        }

        transform.position = pointA.position;
        target = pointA.position;
    }

    void Update()
    {
        // движение
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // если дошла до цели — стоим
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            if (playerOn)
                target = pointB.position; // если игрок на платформе — едем к B
            else
                target = pointA.position; // если игрок ушёл — возвращаемся домой
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOn = true;
            target = pointB.position;
            other.transform.SetParent(transform); // чтобы игрок ехал вместе
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOn = false;
            target = pointA.position;
            other.transform.SetParent(null); // открепляем игрока
        }
    }
