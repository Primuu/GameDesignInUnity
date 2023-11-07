using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public float openDistance = 5.0f; 
    public float slideSpeed = 3.0f;
    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool playerInTrigger = false;

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = new Vector3(closedPosition.x + openDistance, closedPosition.y, closedPosition.z);
    }

    private void Update()
    {
        if (playerInTrigger)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, slideSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, slideSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
}
