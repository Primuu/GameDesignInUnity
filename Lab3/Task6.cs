using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task6 : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private float yVelocity = 0.0f;
    
    private void Update()
    {
        // SmoothDamp
        float newPositionY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);

        // Lerp
        // transform.position = Vector3.Lerp(transform.position, target.position, smoothTime);
    }

}
