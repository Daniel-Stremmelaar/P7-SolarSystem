﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : SelectableObject
{
    //public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        uiElement.transform.position = transform.position;
        uiElement.transform.rotation = transform.rotation;
    }
}
