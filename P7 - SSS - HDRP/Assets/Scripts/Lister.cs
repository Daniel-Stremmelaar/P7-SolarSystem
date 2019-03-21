using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List", menuName = "List Data")]
public class Lister : ScriptableObject
{
    public List<GameObject> objects = new List<GameObject>();
    public List<Sprite> image = new List<Sprite>();
}
