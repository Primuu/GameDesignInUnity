using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 200f;

    // Modifications 
    private float verticalRotation = 0f;

    void Start()
    {
        // ESC key to deactivate cursour
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        verticalRotation -= mouseYMove;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.localEulerAngles = new Vector3(verticalRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseXMove);
    }
}