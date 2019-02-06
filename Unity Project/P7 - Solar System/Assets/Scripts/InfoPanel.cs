using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : SelectableObject
{
    public float elementDistance;
    // Start is called before the first frame update
    void Start()
    {
        //needs conversion to world space
        uiElementOffset = transform.forward * elementDistance;
    }

    // Update is called once per frame
    void Update()
    {
        //needs conversion to world space
        uiElement.transform.position = transform.position + uiElementOffset;
        uiElement.transform.rotation.SetLookRotation(transform.forward, transform.up);
    }
}
