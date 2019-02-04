﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class InformationBox : MonoBehaviour {
    public UniverseObject currentObject;
    public TextMeshProUGUI nameTextObject;
    public TextMeshProUGUI massTextObject;
    public TextMeshProUGUI radiusTextObject;
    public TextMeshProUGUI rotationTextObject;

    void Update () {
        SetValues ();
    }

    void SetValues () {
        nameTextObject.text = currentObject.name;
        massTextObject.text = currentObject.mass.ToString ();
        radiusTextObject.text = currentObject.radius.ToString ();
        rotationTextObject.text = currentObject.rotationLength.ToString();


    }

}