using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUIPosition : MonoBehaviour
{
    public RectTransform UIElement;

    // Update is called once per frame
    void Update()
    {
        UIElement.SetPositionAndRotation(transform.position, transform.rotation);
    }
}
