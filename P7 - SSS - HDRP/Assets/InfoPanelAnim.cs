using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfoPanelAnim : MonoBehaviour
{

    [SerializeField] Animator anim;
    [SerializeField] UnityEvent ev;
    [SerializeField] UnityEvent ev2;

    void Start()
    {
        Invoke("InvokeActie", 0.01f);
        Invoke("SecondInvoke", 0.1f);
    }

    //Stefan zij het, dus nu is de naam dit lol
    void InvokeActie()
    {
        ev.Invoke();
    }

    void SecondInvoke()
    {
        ev2.Invoke();
    }

    public void SetAnim(float point)
    {
        anim.enabled = true;
        anim.Play("UIExtra", 0, point);
    }
}
