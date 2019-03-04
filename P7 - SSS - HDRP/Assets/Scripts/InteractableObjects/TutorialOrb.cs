using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialOrb : InteractableObject
{
    public List<string> tasks;
    public TextMeshPro tutorialText;

    int index;

    private void Start()
    {
        index = 0;
        SetText();
    }

    public override void Interact()
    {
        base.Interact();
        SwitchTask(1);
    }

    // Switch the task. False is previous and true is next task.
    public void SwitchTask(int i)
    {
        index += i;
        SetText();
    }

    public void SetText()
    {
        tutorialText.text = tasks[index];
    }
}
