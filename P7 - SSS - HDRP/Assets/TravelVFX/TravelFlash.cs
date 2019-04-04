using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelFlash : MonoBehaviour {

    public AnimationCurve opacityOverTime;

    GameObject panel;

    public GameObject panelPrefab;

    private float timer = 0f;

    Color color;


    public void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas");

        panel = Instantiate(panelPrefab,canvas.transform);

        color = panel.GetComponent<Image>().color;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        color.a = opacityOverTime.Evaluate(timer);
        panel.GetComponent<Image>().color = color;
    }

}
