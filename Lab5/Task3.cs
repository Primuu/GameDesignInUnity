using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform3 : MonoBehaviour
{
    public List<Vector3> waypoints;
    public int currentWaypointIndex = 0;
    public float speed = 2f;
    public float reachThreshold = 0.1f;

    private bool isMoving = false;

    private void Update()
    {
        if (waypoints.Count > 1 && !isMoving)
        {
            StartCoroutine(MoveToWaypoints());
        }
    }

    IEnumerator MoveToWaypoints()
    {
        isMoving = true;
        Vector3 nextWaypoint = waypoints[currentWaypointIndex];

        while (Vector3.Distance(transform.position, nextWaypoint) > reachThreshold)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, speed * Time.deltaTime);
            yield return null;
        }

        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Count)
        {
            waypoints.Reverse();
            currentWaypointIndex = 0;
        }

        isMoving = false;
    }
}
