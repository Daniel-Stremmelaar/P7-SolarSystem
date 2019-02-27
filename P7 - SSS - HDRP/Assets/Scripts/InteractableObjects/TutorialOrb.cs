using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOrb : InteractableObject
{
    public TutorialText tutText;

    public override void Interact()
    {
        base.Interact();
        tutText.NextTask();
    }
}
