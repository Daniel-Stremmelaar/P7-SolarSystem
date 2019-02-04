using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Universe Object", menuName = "Universe Object")]
public class UniverseObject : ScriptableObject {
    [Header ("Basic")]

    [Tooltip ("Name of the object")]
    public new string name;

    [Header ("Values")]

    [Tooltip ("Mass of the object in kg")]
    public float mass;

    [Tooltip ("Radius of the object in km")]
    public float radius;

}