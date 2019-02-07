using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public Transform uiElement;
    public Vector3 uiElementOffset;

    void Update()
    {
        uiElement.transform.position = transform.position + uiElementOffset;
    }
}
