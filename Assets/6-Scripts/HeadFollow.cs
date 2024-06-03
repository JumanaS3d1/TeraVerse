using UnityEngine;

public class HeadFollow : MonoBehaviour
{
    public Transform player;            // Reference to the player transform
    public Transform headBone;          // Reference to the head bone transform
    public float rotationSpeed = 5f;    // Speed of head rotation
    public Vector2 pitchLimits = new Vector2(-45f, 45f); // Limit pitch rotation (up and down)
    public Vector2 yawLimits = new Vector2(-90f, 90f);   // Limit yaw rotation (left and right)

    void Update()
    {
        if (player == null || headBone == null) return;

        // Calculate direction from head to player
        Vector3 direction = player.position - headBone.position;

        // Calculate target rotation
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Extract pitch (x) and yaw (y) from the target rotation
        Vector3 targetEuler = targetRotation.eulerAngles;
        float pitch = targetEuler.x;
        float yaw = targetEuler.y;

        // Convert pitch and yaw to a range of -180 to 180
        if (pitch > 180) pitch -= 360;
        if (yaw > 180) yaw -= 360;

        // Clamp pitch and yaw
        pitch = Mathf.Clamp(pitch, pitchLimits.x, pitchLimits.y);
        yaw = Mathf.Clamp(yaw, yawLimits.x, yawLimits.y);

        // Apply clamped rotation to the head bone
        Quaternion clampedRotation = Quaternion.Euler(pitch, yaw, 0);
        headBone.rotation = Quaternion.Slerp(headBone.rotation, clampedRotation, Time.deltaTime * rotationSpeed);
        print(headBone.rotation);
    }
}
