using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class InteractionController : VRController
{
    [Header("Interaction")]
    public GameObject interactText;
    public int interactionRange;
    private RaycastHit hit;
    public LineRenderer line;
    public List<Vector3> positions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        positions[0] = transform.position;
        line.SetPosition(0, positions[0]);
    }

    // Update is called once per frame
    void Update()
    {
        positions[1] = transform.position + (transform.forward * interactionRange);
        line.SetPosition(1, positions[1]);
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
