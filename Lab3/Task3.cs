using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    public float speed = 10.0f;
    private float distacneToMove = 10.0f;
    private int direction = 0;
    private Vector3 initialPosition;
    private Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position; 
        CalculateTargetPosition();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            direction = (direction + 1) % 4;
            CalculateTargetPosition();
            transform.Rotate(0, -90, 0);
        }
    }
    
    void CalculateTargetPosition()
    {
        switch (direction)
        {
            case 0:
                targetPosition = initialPosition + new Vector3(distacneToMove, 0, 0);
                break;
            case 1:
                targetPosition = initialPosition + new Vector3(distacneToMove, 0, distacneToMove);
                break;
            case 2:
                targetPosition = initialPosition + new Vector3(0, 0, distacneToMove);
                break;
            case 3:
                targetPosition = initialPosition;
                break;
        }
    }

}
