﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSelector : SelectableObject
{
    [Header("Mechanical")]
    public Text planetName;
    public PlanetButton travel;
    public int change;

    public override void Interact()
    {
        travel.number += change;
        if(travel.number < 0)
        {
            travel.number = travel.planets.Count - 1;
        }
        if(travel.number > travel.planets.Count - 1)
        {
            travel.number = 0;
        }
        planetName.text = travel.planets[travel.number].name;
        if(travel.images[travel.number] != null)
        {
            travel.gameObject.GetComponent<Image>().sprite = travel.images[travel.number];
        }
    }
}
