using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    [Header("Data")]
    public int surface;
    public List<Planet> moons = new List<Planet>();
    public List<Sprite> images = new List<Sprite>();
    public Vector3 position;
    public Vector3 rotation;

    [Header("Info")]
    [TextArea] public string panel1Info;
    [TextArea] public string panel2Info;

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
