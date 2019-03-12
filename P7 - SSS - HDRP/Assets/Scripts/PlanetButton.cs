using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetButton : SelectableObject
{
    public List<GameObject> planets = new List<GameObject>();
    public int number;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Interact()
    {
        foreach (GameObject g in planets)
        {
            g.SetActive(false);
        }
        player.transform.position = planets[number].GetComponent<Planet>().position;
        planets[number].SetActive(true);
    }
}
