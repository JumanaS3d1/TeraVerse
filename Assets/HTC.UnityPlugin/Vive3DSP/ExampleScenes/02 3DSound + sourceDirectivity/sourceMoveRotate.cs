using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sourceMoveRotate : MonoBehaviour
{
    public GameObject AudioSource;


    public float speed = 25F;
    private Vector3 myPosition;
    // Start is called before the first frame update
    void Start()
    {
        myPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //float z = Input.GetAxis("Vertical");
        float z = transform.position.z;
        transform.Rotate(0F, speed * Time.deltaTime, 0F);


    }
}
