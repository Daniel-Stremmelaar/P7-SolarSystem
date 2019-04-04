using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelFlash : MonoBehaviour {

    public AnimationCurve opacityOverTime;

    public GameObject panel;

    private float timer = 0f;

    public bool play;

    Color color;


    public void Awake()
    {
        play = false;

        GameObject canvas = GameObject.Find("Canvas");

        color = panel.GetComponent<Image>().color;
    }

    public void Update()
    {
        if(play == true)
        {
            timer += Time.deltaTime;
            color.a = opacityOverTime.Evaluate(timer);
            panel.GetComponent<Image>().color = color;
            if(timer > 1.1f)
            {
                play = false;
            }
        }
        else
        {
            timer = 0.0f;
        }
        
    }

}
