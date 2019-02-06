using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : VRController
{
    [Header("Interaction")]
    public GameObject interactText;
    public int interactionRange;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * interactionRange);
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
        {
            print("hit");
            if(hit.transform.gameObject.tag == "Interactable")
            {
                print("find");
                if (interactText.activeSelf == false)
                {
                    interactText.SetActive(true);
                }
                if (trigger.GetStateDown(inputSource))
                {
                    print("activate");
                }
            }
        }
        else if (interactText.activeSelf == true)
        {
            interactText.SetActive(false);
        }
    }
}
