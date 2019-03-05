using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Valve.VR;

public class TutorialOrb : InteractableObject
{
    public GameObject[] slides;
    public Task[] tasks;
    public Sprite checkedSprite;
    bool canCompleteTasks;
    bool finishedTasks;


    public SteamVR_Input_Sources inputSource;
    public SteamVR_Action_Boolean trigger;

    public SteamVR_Action_Vector2 trackPad;
    public SteamVR_Action_Boolean trackPress;
    public SteamVR_Action_Boolean infoToggle;

    int index;
    private void Start()
    {
        index = 0;
        foreach(GameObject slide in slides)
        {
            slide.SetActive(false);
        }

        slides[0].SetActive(true);
    }

    public void NextSlide()
    {
        index += 1;

        if(index != slides.Length + 1)
        {
            slides[index - 1].SetActive(false);
            slides[index].SetActive(true);
        } else
        {
            FinishTutorial();
        }

    }

    private void Update()
    {
    if(canCompleteTasks)
           
        {
            CheckTask();
        }
    }

    void CheckTask()
    {
        if (trackPad.GetAxis(inputSource).x > 0.7 && trackPress.GetStateDown(inputSource))
        {
            tasks[1].isDone = true;
            tasks[1].checkmark.sprite = checkedSprite;
        }

        if (trackPad.GetAxis(inputSource).x < -0.7 && trackPress.GetStateDown(inputSource))
        {
            tasks[1].isDone = true;
            tasks[1].checkmark.sprite = checkedSprite;
        }

        if (trackPad.GetAxis(inputSource).y > 0.7 && trackPress.GetStateDown(inputSource))
        {
            tasks[2].isDone = true;
            tasks[2].checkmark.sprite = checkedSprite;
        }

        if (trackPad.GetAxis(inputSource).y < -0.7 && trackPress.GetStateDown(inputSource))
        {

        }
        
        if(infoToggle.GetStateDown(inputSource))
        {
            tasks[0].isDone = true;
            tasks[0].checkmark.sprite = checkedSprite;
        }

        bool allFinished = true;

        foreach(Task t in tasks)
        {
            if(!t.isDone)
            {
                allFinished = false;
                break;
            }
        }

        if(allFinished)
        {
            canCompleteTasks = false;
            finishedTasks = true;
            NextSlide();
        }


    }

    public override void Interact()
    {
        canCompleteTasks = true;
        if(finishedTasks)
        {
            FinishTutorial();
        } else
        {
            NextSlide();
        }
    }

    void FinishTutorial()
    {

    }
}
