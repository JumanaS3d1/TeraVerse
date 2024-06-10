using HTC.UnityPlugin.Vive3DSP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearFieldAction : MonoBehaviour
{
    Vive3DSPAudioSource source;
   

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<Vive3DSPAudioSource>();
        source.NearfieldIntensity = 5;
        source.Nearfield = true;
    }

    public void Intensity1Click() { source.NearfieldIntensity = 1; }
    public void Intensity5Click() { source.NearfieldIntensity = 5; }
    public void Intensity10Click() { source.NearfieldIntensity = 10; }

    public void OnBtnClick() { source.Nearfield = true; }

    public void OffBtnClick() { source.Nearfield = false; }


}
