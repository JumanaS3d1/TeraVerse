using HTC.UnityPlugin.Vive3DSP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class occButtonAction : MonoBehaviour
{
    Vive3DSPAudioGeometricOcclusion geoOcc;
    Vive3DSPAudioRaycastOcclusion rayOcc;
    private Vector3 myPositionInit;
    private bool moveRight = true;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        myPositionInit = transform.position;
        
        geoOcc = GetComponent<Vive3DSPAudioGeometricOcclusion>();
        rayOcc = GetComponent<Vive3DSPAudioRaycastOcclusion>();

        geoOcc.OcclusionEffect = true;
        geoOcc.OcclusionMaterial = OccMaterial.Curtain;
        rayOcc.OcclusionEffect = false;
        rayOcc.OcclusionMaterial = OccMaterial.Curtain;
    }

    public void geoButtonClick(){
        geoOcc.OcclusionEffect = true;
        rayOcc.OcclusionEffect = false;
    }
    public void rayButtonClick(){
        rayOcc.OcclusionEffect = true;
        geoOcc.OcclusionEffect = false;
    }

    public void noneButtonClick(){        
        geoOcc.OcclusionMaterial = OccMaterial.None;
        rayOcc.OcclusionMaterial = OccMaterial.None;
    }
    public void curtainButtonClick(){
        geoOcc.OcclusionMaterial = OccMaterial.Curtain;
        rayOcc.OcclusionMaterial = OccMaterial.Curtain;
    }
    public void concreteButtonClick(){
        geoOcc.OcclusionMaterial = OccMaterial.Concrete;
        rayOcc.OcclusionMaterial = OccMaterial.Concrete;
    }

    void Update()
    {
        if ((myPositionInit.x - transform.position.x)>4)
        {
            moveRight = true;
        }
        if((myPositionInit.x - transform.position.x) < -4)
        {
            moveRight = false;
        }
        if (moveRight == true)
        {
            transform.position += new Vector3(4 * speed * Time.deltaTime, 0F, 0F);
        }
        if (moveRight == false)
        {
            transform.position -= new Vector3(4 * speed * Time.deltaTime, 0F, 0F);
        }
    }
}
