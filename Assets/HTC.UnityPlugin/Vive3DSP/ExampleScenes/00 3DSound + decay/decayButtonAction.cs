using HTC.UnityPlugin.Vive3DSP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decayButtonAction : MonoBehaviour
{
    Vive3DSPAudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<Vive3DSPAudioSource>();
        source.SoundDecayMode = SoundDecayMode.PointSourceDecay;
    }

    public void PointSourceButtonClick(){ source.SoundDecayMode = SoundDecayMode.PointSourceDecay; }
    public void LineSourceButtonClick(){ source.SoundDecayMode = SoundDecayMode.LineSourceDecay; } 
    public void LinearButtonClick(){ source.SoundDecayMode = SoundDecayMode.LinearDecay; }
    public void noDecayButtonClick(){ source.SoundDecayMode = SoundDecayMode.NoDecay; } 

}
