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
        panelTracker.GetComponent<InfoPanel>().uiElement = panels[0].transform;
        panels[0].SetActive(true);
    }

    public void SwitchPanel(int i)
    {
        count += i;
        foreach (GameObject g in panels)
        {
            g.SetActive(false);
        }
        if (count > panels.Count - 1)
        {
            count = 1;
        }
        if (count < 1)
        {
            count = panels.Count - 1;
        }
        if (i == 0)
        {
            if (panels[i].active == true)
            {
                panelTracker.GetComponent<InfoPanel>().uiElement = panels[count].transform;
                panels[count].SetActive(true);
                panels[i].SetActive(false);
            }
            else
            {
                panelTracker.GetComponent<InfoPanel>().uiElement = panels[i].transform;
                panels[i].SetActive(true);
            }
        }
        else
        {
            panelTracker.GetComponent<InfoPanel>().uiElement = panels[count].transform;
            panels[count].SetActive(true);
        }
    }
}
