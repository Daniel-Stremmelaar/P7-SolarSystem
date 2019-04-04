using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GalaxyController : MonoBehaviour
{
    public Vector3 position1;
    public Vector3 position2;
    public Button back;
    public float upScale;

    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(transform.position == position1)
            {
                transform.position = position2;
            }
            else
            {
                transform.position = position1;
            }
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Time.timeScale *= upScale;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                Time.timeScale /= upScale;
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            Time.timeScale = 1;
        }
    }

    private void Back()
    {
        SceneManager.LoadScene(0);
    }
}
