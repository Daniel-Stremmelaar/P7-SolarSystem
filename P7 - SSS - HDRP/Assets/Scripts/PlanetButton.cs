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
        /*foreach(GameObject g in GameObject.FindGameObjectsWithTag("Planet"))
        {
            planets.Add(g);
        }*/
    }

    public override void Interact()
    {
        player.transform.position = planets[number].GetComponent<Planet>().position;
    }
}
