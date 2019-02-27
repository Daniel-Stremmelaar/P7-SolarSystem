using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public new string name;
    public virtual void Interact()
    {
        print("Interacting with " + name + "!");
    }
}
