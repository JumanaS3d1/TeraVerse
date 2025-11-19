using System.Collections;
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

    public GameObject stoutFish;
    public GameObject stoutPos;

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
              //  stoutTimeline.SetActive(true);
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

    public void SetStoutParent() {
        StartCoroutine(SmoothTransition());
       /* stoutFish.transform.SetParent(stoutPos.transform);
        stoutFish.transform.position = stoutPos.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(0, -188.524f, 0));
        stoutFish.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * submarineController.GetCurrentSpeed());*/
   
    }

    public float transitionDuration = 4.0f;

    private IEnumerator SmoothTransition()
    {
        float elapsedTime = 0.0f;
        Vector3 startingPosition = stoutFish.transform.position;
        Quaternion startingRotation = stoutFish.transform.rotation;
        Vector3 targetPosition = stoutPos.transform.position;
        Quaternion targetRotation = stoutPos.transform.rotation; //Quaternion.LookRotation(new Vector3(0, -188.524f, 0));

        // Optionally set the parent at the start to ensure it follows the stoutPos
        stoutFish.transform.SetParent(stoutPos.transform);

        while (elapsedTime < transitionDuration)
        {
            // Calculate the fraction of completion
            float t = elapsedTime / transitionDuration;

            // Smoothly interpolate position and rotation
            stoutFish.transform.position = Vector3.Lerp(startingPosition, targetPosition, t);
            stoutFish.transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, t);

            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Yield to the next frame
            yield return null;
        }

        // Ensure the final position and rotation are set
        stoutFish.transform.position = targetPosition;
        stoutFish.transform.rotation = targetRotation;

        // Ensure the parent is set correctly at the end if needed
        stoutFish.transform.SetParent(stoutPos.transform);
    }
}
