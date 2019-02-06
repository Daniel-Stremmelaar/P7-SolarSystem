using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header ("Menu Buttons")]
    public Button mainMenu;
    public Button game;
    public Button options;
    public Button quitGame;

    private Scene scene;
    private GameObject liveOptions;

    // Start is called before the first frame update
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if(GameObject.FindGameObjectWithTag("Options") != null)
        {
            liveOptions = GameObject.FindGameObjectWithTag("Options");
        }
    }

    void Start()
    {
        if(mainMenu != null)
        {
            mainMenu.onClick.AddListener(delegate { SceneManager.LoadScene(0); });
        }
        if(game != null)
        {
            if(scene.buildIndex != 1)
            {
                game.onClick.AddListener(delegate { SceneManager.LoadScene(1); });
            }
            else
            {
                game.onClick.AddListener(delegate { Time.timeScale = 1; });
            }
        }
        if(options != null)
        {
            if(scene.buildIndex != 2 && liveOptions != null)
            {
                liveOptions.SetActive(true);
                Time.timeScale = 0;
            }
            if(scene.buildIndex == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
        if(quitGame != null)
        {
            quitGame.onClick.AddListener(Application.Quit);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
