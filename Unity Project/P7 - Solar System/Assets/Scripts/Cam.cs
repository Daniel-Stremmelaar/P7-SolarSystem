using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField]
    Vector3 curCamVel = Vector3.zero;
    [SerializeField]
    float freeCamRotSpeed = 40;
    [SerializeField]
    float camAcceleration = 4;


    void Start()
    {
        if(Application.isEditor == true){
             Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        FreeCam();
    }
    void FreeCam()
    {
        curCamVel = Vector3.Lerp(curCamVel, new Vector3(-Input.GetAxis("Mouse Y") * freeCamRotSpeed, Input.GetAxis("Mouse X") * freeCamRotSpeed, 0), Time.deltaTime * camAcceleration);
        transform.Rotate(curCamVel * Time.deltaTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

        transform.position += transform.TransformDirection(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical")) * Time.deltaTime * 10;

    }
}
