using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InputEvent : MonoBehaviour
{
    public EventArray[] timedEvents;
    [SerializeField] string input = "Roll_P1";
    [SerializeField] bool checkInUpdate = false;

    public void CheckInput()
    {
        if (Input.GetButtonDown(input) == true && IsInvoking("IgnoreInput") == false)
        {
            float curTime = 0;
            for (int i = 0; i < timedEvents.Length; i++)
            {
                curTime += timedEvents[i].waitTime;
                StartCoroutine(CoroutineEvents(curTime, timedEvents[i].curEvent));
                CancelInvoke("IgnoreInput");
                Invoke("IgnoreInput", curTime);
            }
        }
    }

    IEnumerator CoroutineEvents(float time, UnityEvent ev)
    {
        yield return new WaitForSeconds(time);
        ev.Invoke();
    }

    void IgnoreInput()
    {
        //invoke fucntion lol
    }

    void LateUpdate()
    {
        if (checkInUpdate == true)
        {
            CheckInput();
        }
    }
}
