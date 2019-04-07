using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    AudioSource audioSrc;
    float vol = 1;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 1;
    }
    void Update()
    {
        audioSrc.volume = vol;
    }
    public void Volume(float v)
    {
        vol = v;
    }
}
