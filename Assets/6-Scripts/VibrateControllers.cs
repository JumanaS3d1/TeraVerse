using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateControllers : MonoBehaviour
{

    public ControllerHand rightController;
    public ControllerHand leftController;
    protected InputBridge input;
    // Start is called before the first frame update
    void Start()
    {
        input = InputBridge.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoVibration() {

        input.VibrateController(4f, 7f, 17, rightController);
        input.VibrateController(4f, 7f, 17, leftController);
    }
}
