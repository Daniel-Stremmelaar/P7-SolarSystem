using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SingleController : VRController
{
    [Header("Controller")]
    public SteamVR_Action_Boolean menu;
    public SteamVR_Action_Vector2 trackPad;
    public SteamVR_Action_Boolean trackPress;
    public GameObject UIPanel;
    public bool activeMenu;

    [Header("Planets")]
    public List<GameObject> planets = new List<GameObject>();
    public int number;
    public int currentPlanet;
    public GameObject player;
    public List<Sprite> images = new List<Sprite>();

    [Header("Subsystems")]
    public List<Lister> lists = new List<Lister>();

    [Header("UI")]
    public Text planetName;
    public Image planetSprite;

    void Start()
    {
        number = 0;
        Select(0);
        activeMenu = true;
        UIPanel.SetActive(activeMenu);
    }

    void Update()
    {
        if (menu.GetStateDown(inputSource))
        {
            activeMenu = !activeMenu;
            UIPanel.SetActive(activeMenu);
        }

        if (activeMenu == true)
        {
            if (trigger.GetStateDown(inputSource))
            {
                print("travel to planet");
                if( number != currentPlanet)
                {
                    Travel();
                }
                else
                {
                    print("to surface");
                    if (planets[number].scene != null)
                    {
                        SceneManager.LoadScene(planets[number].scene.buildIndex);
                    }
                }
            }

            //trackpad axis: horizontal left number, vertical right number. Left/down = -1, right/up = 1

            if (trackPad.GetAxis(inputSource) != new Vector2(0, 0))
            {
                //print(trackPad.GetAxis(inputSource));
            }

            if (trackPad.GetAxis(inputSource).x > 0.7 && trackPress.GetStateDown(inputSource))
            {
                print("planet count +1");
                Select(1);
            }

            if (trackPad.GetAxis(inputSource).x < -0.7 && trackPress.GetStateDown(inputSource))
            {
                print("planet count -1");
                Select(-1);
            }

            if (trackPad.GetAxis(inputSource).y > 0.7 && trackPress.GetStateDown(inputSource))
            {
                print("to surface");
            }

            if (trackPad.GetAxis(inputSource).y < -0.7 && trackPress.GetStateDown(inputSource))
            {
                print("to galaxy map");
            }
        }

    }

    private void Travel()
    {
        foreach (GameObject g in planets)
        {
            g.SetActive(false);
        }
        player.transform.position = planets[number].GetComponent<Planet>().position;
        planets[number].SetActive(true);
    }

    private void Select(int change)
    {
        number += change;
        if (number < 0)
        {
            number = planets.Count - 1;
        }
        if (number > planets.Count - 1)
        {
            number = 0;
        }
        planetName.text = planets[number].name;
        if (images[number] != null)
        {
            planetSprite.sprite = images[number];
        }
    }
}
