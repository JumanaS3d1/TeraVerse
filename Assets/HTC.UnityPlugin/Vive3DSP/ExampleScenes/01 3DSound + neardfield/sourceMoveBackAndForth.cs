using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sourceMoveBackAndForth : MonoBehaviour
{
    public float speed = 0.5F;
    private float dist;
    private Vector3 myPosition;
    private bool isForward = false;
    public Text text;
    public Text nearFieldStatus;
    public float Distance
    {
        set { dist = value; }
        get { return dist; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        myPosition = transform.position;
        float x = transform.position.x;
        float z = transform.position.z;
        Distance = Mathf.Sqrt(x * x + z * z);

    }

    // Update is called once per frame
    void Update()
    {
        //float z = Input.GetAxis("Vertical");
        float x = transform.position.x;
        float z = transform.position.z;
        dist = Mathf.Sqrt(x * x + z * z);
        Distance = Mathf.Round(dist * 100) / 100;
        
        if (Distance >= 2 )
        {
            isForward = false;
        }
        if (Distance <= 0.2 ){
            isForward = true;
        }
        if (Distance > 1)
        {
            text.text = Distance.ToString();
        }

        if (Distance <= 1)
        {
            text.text = ("<color=blue>" + Distance.ToString() + "</color>");
        }

        if (isForward)
        {
            transform.position += new Vector3((myPosition.x - 0.1F) * speed * Time.deltaTime, 0F, myPosition.z * speed * Time.deltaTime);
        }

        if (!isForward)
        {
            transform.position -= new Vector3((myPosition.x - 0.1F) * speed * Time.deltaTime, 0F, myPosition.z * speed * Time.deltaTime);
        }

        

    }
}
