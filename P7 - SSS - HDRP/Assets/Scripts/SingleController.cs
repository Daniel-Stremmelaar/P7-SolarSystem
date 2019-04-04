using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingleController : MonoBehaviour
{
    [Header("Controller")]
    public GameObject UIPanel;
    public bool activeMenu;

    [Header("Data")]
    //public List<GameObject> planets = new List<GameObject>();
    public int number;
    public int currentPlanet;
    public int listNr;
    public int currentList;
    public GameObject player;
    public Lister moonList;
    public GameObject activePlanet;
    public float upScale;
    public Lister heavenBodies;
    public GameObject info1;
    public GameObject info2;

    [Header("Objects")]
    public List<Lister> lists = new List<Lister>();

    [Header("UI")]
    public Text planetName;
    public Image planetSprite;
    public Button previous;
    public Button next;
    public Button surface;
    public Button galaxy;
    public Button travel;
    public Button toggle;
    public Button toggleTwo;
    public Button listChange;
    public Button exit;

    void Start()
    {
        listNr = 0;
        number = 0;
        currentPlanet = -1;
        Select(0);
        Travel();
        activeMenu = true;
        UIPanel.SetActive(activeMenu);

        previous.onClick.AddListener(delegate { Select(-1); });
        next.onClick.AddListener(delegate { Select(1); });
        surface.onClick.AddListener(ToSurface);
        travel.onClick.AddListener(Travel);
        toggle.onClick.AddListener(MenuToggle);
        toggleTwo.onClick.AddListener(MenuToggle);
        listChange.onClick.AddListener(delegate { Browse(1); });
        exit.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        //if button, menu toggle
        /*
        if (activeMenu == true)
        {
            // Control scheme 1: travel

            // if button, travel to surface of current planet

            else
            {
                // Control scheme 2: zoom
                if (trackPad.GetAxis(inputSource).y > 0.7 && trackPress.GetStateDown(inputSource))
                {
                    activePlanet.gameObject.transform.localScale *= upScale;
                }

                if (trackPad.GetAxis(inputSource).y < -0.7 && trackPress.GetStateDown(inputSource))
                {
                    activePlanet.gameObject.transform.localScale /= upScale;
                }

                if (trackPad.GetAxis(inputSource).x > 0.7 && trackPress.GetStateDown(inputSource))
                {
                    Time.timeScale *= upScale;
                }

                if (trackPad.GetAxis(inputSource).x < -0.7 && trackPress.GetStateDown(inputSource))
                {
                    Time.timeScale /= upScale;
                }
            }
            */

    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void MenuToggle()
    {
        activeMenu = !activeMenu;
        UIPanel.SetActive(activeMenu);
        toggleTwo.gameObject.SetActive(!activeMenu);
    }

    private void ToSurface()
    {
        print("to surface");
        if (SceneManager.GetActiveScene().name != SceneManager.GetSceneByBuildIndex(lists[listNr].objects[number].surface).name)
        {
            SceneManager.LoadScene(lists[listNr].objects[number].surface);
        }
    }

    private void Travel()
    {
        foreach (Planet g in heavenBodies.objects)
        {
            g.gameObject.SetActive(false);
        }
        currentPlanet = number;
        currentList = listNr;
        if (listNr == 0)
        {
            moonList.objects = lists[0].objects[currentPlanet].moons;
            moonList.image = lists[0].objects[currentPlanet].images;
        }
        activePlanet = lists[listNr].objects[number].gameObject;
        activePlanet.transform.localScale = new Vector3(1, 1, 1);
        Time.timeScale = 1;
        player.transform.position = activePlanet.GetComponent<Planet>().position;
        activePlanet.SetActive(true);

        if(lists[listNr].objects[number].surface != 0)
        {
            surface.gameObject.GetComponentInChildren<Text>().text = lists[listNr].objects[number].name + " surface";
        }
        else
        {
            surface.gameObject.GetComponentInChildren<Text>().text = "Unavailable";
        }

        if (listNr == 0)
        {
            if (lists[listNr].objects[number].moons.Count < 1)
            {
                listChange.gameObject.GetComponentInChildren<Text>().text = "Unavailable";
            }
            else
            {
                if (listNr == 0)
                {
                    listChange.gameObject.GetComponentInChildren<Text>().text = "To Moons";
                }
                if (listNr == 1)
                {
                    listChange.gameObject.GetComponentInChildren<Text>().text = "To Planets";
                }
            }
        }
        if(listNr == 1)
        {
            listChange.gameObject.GetComponentInChildren<Text>().text = "To Planets";
        }

        info1.GetComponent<Text>().text = lists[currentList].objects[currentPlanet].panel1Info;
        info2.GetComponent<Text>().text = lists[currentList].objects[currentPlanet].panel2Info;

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
        if (listNr < 0)
        {
            listNr = lists.Count - 1;
        }
        if (listNr > lists.Count - 1)
        {
            listNr = 0;
        }

        if (lists[listNr].objects.Count > 0)
        {
            if (listNr == 0)
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

        if(moonList.objects.Count > 0)
        {
            if (listNr == 0)
            {
                listChange.gameObject.GetComponentInChildren<Text>().text = "To Moons";
            }
            if (listNr == 1)
            {
                listChange.gameObject.GetComponentInChildren<Text>().text = "To Planets";
            }
        }
        else
        {
            listChange.gameObject.GetComponentInChildren<Text>().text = "Unavailable";
        }
    }
}
