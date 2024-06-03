using UnityEngine;
using UnityEngine.Playables;

public class HandWaveDetector : MonoBehaviour
{
    public Transform rightHandTransform; // Reference to the right hand controller transform
    public Transform leftHandTransform;  // Reference to the left hand controller transform
    public float raiseHeightThreshold = 1.5f; // Height threshold to consider hand as raised
    public float waveDistanceThreshold = 0.1f; // Minimum horizontal distance for waving motion
    public int waveCountThreshold = 3; // Minimum number of waves to consider it as a waving action
    public float waveDetectionTime = 1.0f; // Time window to detect waves

    private Vector3 lastRightHandPosition;
    private Vector3 lastLeftHandPosition;
    private int rightHandWaveCount = 0;
    private int leftHandWaveCount = 0;
    private float waveDetectionTimer = 0;

    public PlayableDirector mainTimeline;

    void Start()
    {
        lastRightHandPosition = rightHandTransform.position;
        lastLeftHandPosition = leftHandTransform.position;
    }

    void Update()
    {
        waveDetectionTimer += Time.deltaTime;

        if (waveDetectionTimer >= waveDetectionTime)
        {
            waveDetectionTimer = 0;
            rightHandWaveCount = 0;
            leftHandWaveCount = 0;
        }

        DetectHandWave(rightHandTransform, ref lastRightHandPosition, ref rightHandWaveCount, "Right Hand");
        DetectHandWave(leftHandTransform, ref lastLeftHandPosition, ref leftHandWaveCount, "Left Hand");
    }

    void DetectHandWave(Transform handTransform, ref Vector3 lastHandPosition, ref int handWaveCount, string handName)
    {
        if (handTransform.position.y > raiseHeightThreshold)
        {
            float horizontalMovement = handTransform.position.x - lastHandPosition.x;

            if (Mathf.Abs(horizontalMovement) > waveDistanceThreshold)
            {
                handWaveCount++;
                lastHandPosition = handTransform.position;
            }

            if (handWaveCount >= waveCountThreshold)
            {
                Debug.Log($"{handName} is waving!");
                mainTimeline.Play();
                /* if (mainTimeline != null && mainTimeline.state != PlayState.Playing)
                 {
                     mainTimeline.Play();
                 }*/
                handWaveCount = 0; // Reset wave count after detecting a wave action
            }
        }
    }
}
