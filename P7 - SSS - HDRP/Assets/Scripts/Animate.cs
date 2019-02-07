using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    public bool toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(toggle) {
            GetComponent<Animator>().SetTrigger("Toggle");
            toggle = false;
        }
    }
}
