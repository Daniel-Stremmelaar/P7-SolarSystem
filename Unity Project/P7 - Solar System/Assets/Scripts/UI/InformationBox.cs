using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class InformationBox : MonoBehaviour {
    public UniverseObject currentObject;
    public UniverseObject oldObject;
    public TextMeshProUGUI nameTextObject;
    public TextMeshProUGUI factTextObject;
    public TextMeshProUGUI massTextObject;
    public TextMeshProUGUI radiusTextObject;
    public TextMeshProUGUI rotationTextObject;

    void Start () {
        oldObject = currentObject;
    }

    void Update () {
        if (oldObject != currentObject) {
            SetValues ();
            oldObject = currentObject;
        }
    }

    void SetValues () {
        nameTextObject.text = currentObject.name;
        massTextObject.text = currentObject.mass.ToString ();
        radiusTextObject.text = currentObject.radius.ToString ();
        rotationTextObject.text = currentObject.rotationLength.ToString ();

        string objectFact = "";

        int index = Random.Range (0, currentObject.facts.Count);
        objectFact = currentObject.facts[index];

        factTextObject.text = objectFact;
    }
}