using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : SelectableObject
{
    public float elementDistance;
    //public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        
        uiElementOffset = transform.forward * elementDistance;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        uiElement.transform.position = transform.position + uiElementOffset;
        uiElement.transform.rotation.SetLookRotation(transform.up, transform.forward);
        

        //uiElement.transform.position = controller.transform.position + uiElementOffset;
    }
}
