using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Universe Object", menuName = "Universe Object")]
public class UniverseObject : ScriptableObject {
    //Basic information
    [Header ("Basic")]

    [Tooltip ("Name of the object")]
    public new string name;

    [Tooltip("Facts about the object")]
    public List<string> facts;

    //Values of object
    [Header ("Values")]

    [Tooltip ("Mass of the object in kg")]
    public float mass;

    [Tooltip ("Radius of the object in km")]
    public float radius;

    [Tooltip ("Amount of hours it takes to make one full rotation")]
    public float rotationLength;

}