using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform targetPosition;
    public float speed = 3.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private bool isActive = false;

    void Start()
    {
        startPosition = transform.position;
        endPosition = targetPosition.position;
    }

    void Update()
    {
        if (isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);

            if (transform.position == endPosition)
            {
                (startPosition, endPosition) = (endPosition, startPosition);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = false;
        }
    }
}
