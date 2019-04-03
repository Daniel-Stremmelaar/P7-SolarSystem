using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfo : MonoBehaviour
{
    Text txt;
    [SerializeField] string[] text;
    int curText = 0;
    [SerializeField] SingleController control;
    void Start()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        curText = control.currentPlanet;
        txt.text = text[curText];
    }
}
