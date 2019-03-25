using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    public Scene surface;
    public List<Planet> moons = new List<Planet>();
    public List<Sprite> images = new List<Sprite>();
    public Vector3 position;
    public Vector3 rotation;

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
