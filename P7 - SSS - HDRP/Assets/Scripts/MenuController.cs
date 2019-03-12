using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MenuController : VRController
{
    public SteamVR_Action_Vector2 trackPad;
    public SteamVR_Action_Boolean trackPress;

    [Header ("Data")]
    public InfoPanelManager panelManager;
    public GameObject player;
    public GameObject systemMap;
    public int mapDistance;
    private Vector3 mapOffset;
    public GameObject UIPanel;

    [Header("Planets")]
    public List<GameObject> planets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        systemMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger.GetStateDown(inputSource))
        {
            UIPanel.active = !UIPanel.active;
        }

        //trackpad axis: horizontal left number, vertical right number. Left/down = -1, right/up = 1

        if (trackPad.GetAxis(inputSource) != new Vector2 (0,0))
        {
            //print(trackPad.GetAxis(inputSource));
        }

        if(trackPad.GetAxis(inputSource).x > 0.7 && trackPress.GetStateDown(inputSource))
        {
            print("next");
            panelManager.SwitchPanel(1);
        }

        if (trackPad.GetAxis(inputSource).x < -0.7 && trackPress.GetStateDown(inputSource))
        {
            print("next");
            panelManager.SwitchPanel(-1);
        }

        if(trackPad.GetAxis(inputSource).y > 0.7 && trackPress.GetStateDown(inputSource))
        {
            panelManager.SwitchPanel(0);
        }

        if(trackPad.GetAxis(inputSource).y < -0.7 && trackPress.GetStateDown(inputSource))
        {
            panelManager.SwitchPanel(2);
        }

    }
}
