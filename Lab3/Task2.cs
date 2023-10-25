using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    public float speed = 4f;
    private float distacneToMove = 10.0f;
    private int direction = 1;
    private float initialPositionX;

    void Start()
    {
        initialPositionX = transform.position.x;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);

        if (direction == 1 && transform.position.x - initialPositionX >= distacneToMove)
        {
            direction = -1;
        }

        if (direction == -1 && transform.position.x <= initialPositionX)
        {
            direction = 1;
        }
    }

}
