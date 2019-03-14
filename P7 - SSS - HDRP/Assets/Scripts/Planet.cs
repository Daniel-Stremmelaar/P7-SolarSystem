using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Vector3 position;
    public Vector3 rotation;

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
