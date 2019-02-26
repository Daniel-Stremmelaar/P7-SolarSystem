using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelManager : MonoBehaviour
{
    public GameObject panelTracker;
    public int count;
    public List<GameObject> panels = new List<GameObject>();
    // Start is called before the first frame update
    private void Start()
    {
        foreach (GameObject g in panels)
        {
            g.SetActive(false);
        }
        panelTracker.GetComponent<InfoPanel>().uiElement = panels[1].transform;
        panels[1].SetActive(true);
    }

    public void SwitchPanel(int i)
    {
        if (i != 0 && i != 2)
        {
            count += i;
            foreach (GameObject g in panels)
            {
                g.SetActive(false);
            }
        }

        if (count > panels.Count - 1)
        {
            count = 2;
        }
        if (count < 2)
        {
            count = panels.Count - 1;
        }

        if (i == 0 || i == 2)
        {
            if (i == 0)
            {
                if (panels[i].activeInHierarchy)
                {
                    panelTracker.GetComponent<InfoPanel>().uiElement = panels[count].transform;
                    panels[count].SetActive(true);
                    panels[i].SetActive(false);
                }
                else
                {
                    foreach (GameObject g in panels)
                    {
                        g.SetActive(false);
                    }
                    panelTracker.GetComponent<InfoPanel>().uiElement = panels[i].transform;
                    panels[i].SetActive(true);
                }
            }

            if (i == 2)
            {
                if (panels[1].activeInHierarchy)
                {
                    panelTracker.GetComponent<InfoPanel>().uiElement = panels[count].transform;
                    panels[count].SetActive(true);
                    panels[1].SetActive(false);
                }
                else
                {
                    foreach (GameObject g in panels)
                    {
                        g.SetActive(false);
                    }
                    panelTracker.GetComponent<InfoPanel>().uiElement = panels[1].transform;
                    panels[1].SetActive(true);
                }
            }
        }

        else
        {
            panelTracker.GetComponent<InfoPanel>().uiElement = panels[count].transform;
            panels[count].SetActive(true);
        }
    }
}
