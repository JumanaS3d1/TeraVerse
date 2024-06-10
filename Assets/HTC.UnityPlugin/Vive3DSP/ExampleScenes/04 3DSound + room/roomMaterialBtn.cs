using HTC.UnityPlugin.Vive3DSP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomMaterialBtn : MonoBehaviour
{
    Vive3DSPAudioRoom room;
    // Start is called before the first frame update
    void Start()
    {
        room = GetComponent<Vive3DSPAudioRoom>();
        room.ReverbPreset = RoomReverbPreset.Generic;
    }

    public void genericBtn()
    {
        room.ReverbPreset = RoomReverbPreset.Generic;
    }

    public void churchBtn()
    {
        room.ReverbPreset = RoomReverbPreset.Church;
    }

    public void userdefineCurtainBtn()
    {
        room.ReverbPreset = RoomReverbPreset.UserDefine;
        room.Ceiling = RoomPlateMaterial.Curtain;
        room.Floor = RoomPlateMaterial.Curtain;
        room.FrontWall = RoomPlateMaterial.Curtain;
        room.LeftWall = RoomPlateMaterial.Curtain;
        room.RightWall = RoomPlateMaterial.Curtain;
        room.BackWall = RoomPlateMaterial.Curtain;
    }
    public void userdefineConcretenBtn()
    {
        room.ReverbPreset = RoomReverbPreset.UserDefine;
        room.Ceiling = RoomPlateMaterial.Concrete;
        room.Floor = RoomPlateMaterial.Concrete;
        room.FrontWall = RoomPlateMaterial.Concrete;
        room.LeftWall = RoomPlateMaterial.Concrete;
        room.RightWall = RoomPlateMaterial.Concrete;
        room.BackWall = RoomPlateMaterial.Concrete;
    }
    public void bgSmallRoomBtn()
    {
        room.BackgroundType = RoomBackgroundAudioType.SmallRoom;
    }
    public void bgAcRoomBtn()
    {
        room.BackgroundType = RoomBackgroundAudioType.AirConditioner;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
