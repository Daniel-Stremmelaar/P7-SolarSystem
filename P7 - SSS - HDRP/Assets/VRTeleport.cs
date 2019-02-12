using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRTeleport : MonoBehaviour
{

    public Transform testHelp;
    public Image testHelpImg;
    public float fadingSpeed = 20;
    bool fading = false;

    /*
        private void Update()
        {
            if (Input.GetButtonDown("Fire1") == true)
            {
                Teleport(testHelp, new Vector3(0, 0, 10), true, testHelpImg, fadingSpeed);
                //LoadScene(0, testHelpImg, fadingSpeed);
            }
        }
    */
    void Teleport(Transform toTeleport, Vector3 newPosition, bool addPosition, Image fadeImage, float fadeSpeed)
    {
        if (fading == false)
        {
            if (addPosition == true)
            {
                StartCoroutine(FadeTeleport(fadeImage, toTeleport, toTeleport.position + newPosition, fadeSpeed));
            }
            else
            {
                StartCoroutine(FadeTeleport(fadeImage, toTeleport, newPosition, fadeSpeed));
            }
        }
    }

    IEnumerator FadeTeleport(Image fadeImage, Transform toTeleport, Vector3 newPos, float fadeSpeed)
    {
        fading = true;
        fadeImage.color = Color.clear;
        while (fadeImage.color != Color.black)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.black, Time.deltaTime * fadeSpeed);
            yield return new WaitForEndOfFrame();
        }
        toTeleport.position = newPos;
        while (fadeImage.color != Color.clear)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, Time.deltaTime * fadeSpeed);
            yield return new WaitForEndOfFrame();
        }
        fading = false;
    }

    void Teleport(Transform toTeleport, bool addPosition, Vector3 newPosition)
    {
        if (addPosition == true)
        {
            toTeleport.position += newPosition;
        }
        else
        {
            toTeleport.position = newPosition;
        }
    }

    void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    void LoadScene(int scene, Image fadeImage, float fadeSpeed)
    {
        if (fading == false)
        {
            StartCoroutine(FadeLoad(scene, "", fadeImage, fadeSpeed));
        }
    }

    void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void LoadScene(string scene, Image fadeImage, float fadeSpeed)
    {
        if (fading == false)
        {
            StartCoroutine(FadeLoad(0, scene, fadeImage, fadeSpeed));
        }
    }
    IEnumerator FadeLoad(int sceneInt, string sceneString, Image fadeImage, float fadeSpeed)
    {
        fading = true;
        fadeImage.color = Color.clear;
        while (fadeImage.color != Color.black)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.black, Time.deltaTime * fadeSpeed);
            yield return new WaitForEndOfFrame();
        }
        if (sceneString != "")
        {
            SceneManager.LoadScene(sceneString);
        }
        else
        {
            SceneManager.LoadScene(sceneInt);
        }
        while (fadeImage.color != Color.clear)
        {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, Time.deltaTime * fadeSpeed);
            yield return new WaitForEndOfFrame();
        }
        fading = false;
    }

}
