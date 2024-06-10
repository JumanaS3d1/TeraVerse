using HTC.UnityPlugin.Vive3DSP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomBtnAction : MonoBehaviour
{
    Vive3DSPAudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<Vive3DSPAudioSource>();
        source.Reverb = true;
    }

    public void roomOffBtn()
    {
        source.Reverb = false;
    }
    public void roomOnBtn()
    {
        source.Reverb = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
