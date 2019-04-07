using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume2 : MonoBehaviour
{
    AudioSource audioSrc;
    float vol = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 0.2f;
    }

    public void Volume(float v)
    {
        vol = v * 0.2f;
        audioSrc.volume = vol;
    }
}
