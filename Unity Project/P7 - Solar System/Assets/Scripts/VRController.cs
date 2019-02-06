using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class VRController : MonoBehaviour
{
    [Header ("VR Input")]
    public SteamVR_Action_Boolean triggerLeft;
    public SteamVR_Input_Sources inputSource1 = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Action_Boolean triggerRight;
    public SteamVR_Input_Sources inputSource2 = SteamVR_Input_Sources.RightHand;
    // Start is called before the first frame update

    private void OnEnable()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerLeft.GetStateDown(inputSource1))
        {
            print("test");
        }
        if (triggerRight.GetStateDown(inputSource2))
        {
            print("succes");
        }
    }
}
