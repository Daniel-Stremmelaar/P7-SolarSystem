using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSound : MonoBehaviour
{
    public void SpawnSoundEffect(AudioClip clip)
    {
        GameObject g = new GameObject();
        g.AddComponent(typeof(AudioSource));
        g.GetComponent<AudioSource>().clip = clip;
        g.GetComponent<AudioSource>().Play();
        Destroy(g, clip.length);
    }
}
