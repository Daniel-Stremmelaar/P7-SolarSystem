using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialText : MonoBehaviour
{
    public List<string> tasks;
    public int index;
    public TextMeshPro taskTMP;

    private void Start()
    {
        index = 0;
        SetText(tasks[index]);
    }

    public void NextTask()
    {
        index += 1;
        SetText(tasks[index]);
    }

    public void SetText(string text)
    {
        taskTMP.text = text;
    }
}
