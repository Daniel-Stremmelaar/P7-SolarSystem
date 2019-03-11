using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvents : MonoBehaviour
{
    
    [SerializeField] EventArray[] events;

    void Start(){
        StartEvents();
    }

    public void StartEvents(){
        float totalTime = 0;
        for (int i = 0; i < events.Length; i++)
        {
            StartCoroutine(ActivateEvent(events[i].curEvent,events[i].waitTime + totalTime));
            totalTime += events[i].waitTime;
        }
    }

    IEnumerator ActivateEvent(UnityEvent ev,float waitTime){
        yield return new WaitForSeconds(waitTime);
        ev.Invoke();
    }
}

[System.Serializable]
public class EventArray
{
    public float waitTime = 1;
    public UnityEvent curEvent;
}
