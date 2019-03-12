using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class InteractionController : VRController
{
    [Header("Interaction")]
    //public GameObject interactText;
    public Transform pointer;
    public GameObject putOnHit;
    public GameObject interactText;
    public int interactionRange;
    private RaycastHit hit;
    public LineRenderer line;
    public List<Vector3> positions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        positions[0] = pointer.position;
        line.SetPosition(0, positions[0]);
    }

    // Update is called once per frame
    void Update()
    {

        positions[0] = pointer.position;
        line.SetPosition(0, positions[0]);

  

        Debug.DrawRay(pointer.position, pointer.forward * interactionRange);

        if (Physics.Raycast(pointer.position, pointer.forward, out hit, interactionRange))
        {
            positions[1] = hit.point;
            print("hit");

            putOnHit.SetActive(true);
            putOnHit.transform.position = hit.point;

            if(hit.transform.gameObject.tag == "Interactable")
            {
                print("find");

                hit.transform.gameObject.GetComponent<SelectableObject>().uiElement = interactText.transform;
                hit.transform.gameObject.GetComponent<SelectableObject>().PlaceText();
                interactText.SetActive(true);

                if (trigger.GetStateDown(inputSource))
                {
                    //Get InteractableObject script
                    print("activate");
                    hit.transform.gameObject.GetComponent<SelectableObject>().Interact();
                }
            }
        }
        else
        {
            interactText.SetActive(false);
            positions[1] = pointer.position + (pointer.forward * interactionRange);
            putOnHit.SetActive(false);
        }

        line.SetPosition(1, positions[1]);
    }
}
