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

    [Header("Data")]
    //public List<GameObject> planets = new List<GameObject>();
    public int number;
    public int currentPlanet;
    public int listNr;
    public GameObject player;
    public Lister moonList;
    //public List<Sprite> images = new List<Sprite>();

    [Header("Objects")]
    public List<Lister> lists = new List<Lister>();

    [Header("UI")]
    public Text planetName;
    public Image planetSprite;

    void Start()
    {
        listNr = 0;
        number = 0;
        currentPlanet = -1;
        Select(0);
        Travel();
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
                    if (lists[listNr].objects[number].surface != null)
                    {
                        SceneManager.LoadScene(lists[listNr].objects[number].surface.buildIndex);
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
                print("list count +1");
                Browse(1);
            }

            if (trackPad.GetAxis(inputSource).y < -0.7 && trackPress.GetStateDown(inputSource))
            {
                print("list count -1");
                Browse(-1);
            }
        }

    }

    private void Travel()
    {
        foreach (Lister g in lists)
        {
            foreach(Planet p in g.objects)
            {
                p.gameObject.SetActive(false);
            }
        }
        currentPlanet = number;
        if(listNr == 0)
        {
            moonList.objects = lists[0].objects[currentPlanet].moons;
            moonList.image = lists[0].objects[currentPlanet].images;
        }
        player.transform.position = lists[listNr].objects[number].GetComponent<Planet>().position;
        lists[listNr].objects[number].gameObject.SetActive(true);
        
    }

    private void Select(int change)
    {
        number += change;
        if (number < 0)
        {
            number = lists[listNr].objects.Count - 1;
        }
        if (number > lists[listNr].objects.Count - 1)
        {
            number = 0;
        }
        planetName.text = lists[listNr].objects[number].name;
        if (lists[listNr].image[number] != null)
        {
            planetSprite.sprite = lists[listNr].image[number];
        }
    }

    private void Browse(int change)
    {
        listNr += change;
        if(listNr < 0)
        {
            listNr = lists.Count - 1;
        }
        if(listNr > lists.Count - 1)
        {
            listNr = 0;
        }

        if(lists[listNr].objects.Count > 0)
        {
            if(listNr == 0)
            {
                number = currentPlanet;
            }
            else
            {
                number = 0;
            }
            Select(0);
        }
        else
        {
            listNr -= change;
            if (listNr < 0)
            {
                listNr = lists.Count - 1;
            }
            if (listNr > lists.Count - 1)
            {
                listNr = 0;
            }
        }

        
    }
}
