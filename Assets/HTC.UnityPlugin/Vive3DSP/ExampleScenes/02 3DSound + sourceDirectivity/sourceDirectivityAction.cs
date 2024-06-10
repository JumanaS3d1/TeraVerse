using HTC.UnityPlugin.Vive3DSP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sourceDirectivityAction : MonoBehaviour
{
    Vive3DSPAudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<Vive3DSPAudioSource>();
        source.Shape = 0.5F;
        source.Focus = 5F;
    }

    public void modeShape00() { source.Shape = 0F; }
    public void modeShape05() { source.Shape = 0.5F; }
    public void modeShape10() { source.Shape = 1F; }

    public void modeFocus01() { source.Focus = 1F; }
    public void modeFocus05() { source.Focus = 5F; }
    public void modeFocus10() { source.Focus = 10F; }


}
