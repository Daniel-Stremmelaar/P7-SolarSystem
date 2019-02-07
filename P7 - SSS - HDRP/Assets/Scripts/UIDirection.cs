using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirection : MonoBehaviour
{
    private Transform playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookPos = playerCamera.position - transform.position;
        transform.LookAt(lookPos);
    }
}
