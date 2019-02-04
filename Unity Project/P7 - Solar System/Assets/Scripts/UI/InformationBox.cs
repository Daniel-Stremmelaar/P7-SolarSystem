using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
public class InformationBox : MonoBehaviour {
    public UniverseObject currentObject;
    public Transform nameTextObject;
    public Transform massTextObject;
    public Transform radiusTextObject;

    void Update () {
        SetValues();
    }

    void SetValues () {
        nameTextObject.GetComponent<TextMeshProUGUI> ().text = 
        currentObject.name;
        massTextObject.GetComponent<TextMeshProUGUI> ().text = 
        currentObject.mass.ToString ();
        radiusTextObject.GetComponent<TextMeshProUGUI> ().text = 
        currentObject.radius.ToString();

    }

}