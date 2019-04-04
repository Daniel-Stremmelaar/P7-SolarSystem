using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Returner : MonoBehaviour
{
    public Button back;

    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(Back);
    }

    private void Back()
    {
        SceneManager.LoadScene(0);
    }
}
