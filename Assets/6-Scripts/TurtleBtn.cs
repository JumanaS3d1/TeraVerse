using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurtleBtn : MonoBehaviour
{
    public GameObject button;
    public UnityEvent OnPress;
    Vector3 initialPos;

    bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        initialPos = new Vector3(button.transform.localPosition.x, button.transform.localPosition.y, button.transform.localPosition.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
            if (!isPressed)
            {
                print("sasasasa");
             //   button.transform.position = new Vector3(1, 0.00984f, -0.00058f);
                // presser = other.gameObject;
                isPressed = true;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            print("dfbbvcbv.,b';.';';.");
           // button.transform.position = initialPos;
            OnPress.Invoke();
        }
    }
}