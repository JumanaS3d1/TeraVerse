using UnityEngine;
using UnityEngine.Events;

public class XRRigPositionerOcean : MonoBehaviour
{
    public Transform targetPosition; // The exact point in the scene where the XR rig should be placed
    public GameObject XRRig;
    public UnityEvent onRepositioned;

    void Start()
    {
        PositionXRRig();
    }

    void Update()
    {
       
    }

    public void PositionXRRig()
    {
        print("setttt");
        // Get the current XR rig's position and rotation
        Transform xrRig = XRRig.transform;

        // Set the XR rig's position and rotation to match the target position
        xrRig.position = targetPosition.position;
        xrRig.rotation = targetPosition.rotation;
        XRRig.transform.SetParent(targetPosition);

        onRepositioned.Invoke();

 /*       // Optionally, reset the camera's local position and rotation to account for any offsets
        xrRig.transform.localPosition = Vector3.zero;
        xrRig.transform.localRotation = Quaternion.identity;*/
    }
}