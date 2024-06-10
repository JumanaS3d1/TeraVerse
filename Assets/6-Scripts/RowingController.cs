using UnityEngine;

public class RowingController : MonoBehaviour
{
    public Transform rightHandTransform; // Reference to the right hand controller transform
    public Transform leftHandTransform;  // Reference to the left hand controller transform
    public float speedIncreaseFactor = 2.0f; // Factor to increase the speed based on hand movement
    public float minSpeed = 5.0f; // Minimum speed of the submarine
    public float maxSpeed = 20.0f; // Maximum speed of the submarine

    private Vector3 lastRightHandPosition;
    private Vector3 lastLeftHandPosition;
    private float currentSpeed;

    void Start()
    {
        lastRightHandPosition = rightHandTransform.position;
        lastLeftHandPosition = leftHandTransform.position;
        currentSpeed = minSpeed; // Start at minimum speed
    }

    void Update()
    {
        float rightHandSpeed = (rightHandTransform.position - lastRightHandPosition).magnitude / Time.deltaTime;
        float leftHandSpeed = (leftHandTransform.position - lastLeftHandPosition).magnitude / Time.deltaTime;

        lastRightHandPosition = rightHandTransform.position;
        lastLeftHandPosition = leftHandTransform.position;

        float handMovementSpeed = rightHandSpeed + leftHandSpeed;

        currentSpeed = Mathf.Clamp(minSpeed + handMovementSpeed * speedIncreaseFactor, minSpeed, maxSpeed);

        MoveSubmarine();
    }

    void MoveSubmarine()
    {
        // Implement this in the next step
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
