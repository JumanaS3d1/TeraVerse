using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive3DSP;

public class FrontCircleMove : MonoBehaviour
{
    public GameObject AudioSource;

    private float currentAngle;
    public float angularSpeed = 1F;
    public float rad = 4F;
    private Vector3 myPosition;

    public void FrontCirclePath()
    {
        currentAngle += angularSpeed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Sin(currentAngle) * rad, 0F, Mathf.Cos(currentAngle) * rad);
        transform.position = myPosition + offset;

    }


    // Start is called before the first frame update
    void Start()
    {
        myPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {

        FrontCirclePath();
    }
}
