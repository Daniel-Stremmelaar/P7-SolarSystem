using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelPos : MonoBehaviour
{
    [SerializeField] SingleController control;
    [SerializeField] Vector3 offset;
    [SerializeField] Renderer rend;

    void Update()
    {
        if (offset.x > 0)
        {
            transform.position = control.activePlanet.transform.position + offset + new Vector3(rend.bounds.extents.magnitude, 0, 0);
        }
        else
        {
            transform.position = control.activePlanet.transform.position + offset - new Vector3(rend.bounds.extents.magnitude, 0, 0);
        }
    }
}
