using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints to define the path
    public RowingController submarineController; // Reference to the SubmarineController script

    private int currentWaypointIndex = 0;
    private bool isStopped = false;
    private Vector3 currentVelocity = Vector3.zero; // Used by SmoothDamp

    public float smoothTime = 0.3f; // Time to smooth the movement
    public GameObject turtleTimeline;
    public GameObject stoutTimeline;

    void Update()
    {
        if (waypoints.Length == 0 || isStopped) return;

        float speed = submarineController.GetCurrentSpeed();
        Vector3 currentWaypoint = waypoints[currentWaypointIndex].position;

        // Smoothly move towards the current waypoint
        transform.position = Vector3.SmoothDamp(transform.position, currentWaypoint, ref currentVelocity, smoothTime, speed);

        // Check if the submarine has reached the current waypoint
        if (Vector3.Distance(transform.position, currentWaypoint) < 0.1f)
        {
            currentWaypointIndex++;

            // Check if we've reached the last waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                isStopped = true;
                turtleTimeline.SetActive(false);
                stoutTimeline.SetActive(true);
                currentWaypointIndex = waypoints.Length - 1; // Stay at the last waypoint
            }
        }

        // Smoothly look at the next waypoint if it exists
        if (currentWaypointIndex < waypoints.Length - 1)
        {
            Vector3 nextWaypoint = waypoints[currentWaypointIndex + 1].position;
            Vector3 direction = (nextWaypoint - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }
}
