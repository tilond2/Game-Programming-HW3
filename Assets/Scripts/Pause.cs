using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPaused;
    public GameObject pauseMenu;
    GameObject music;
    AudioSource song;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        music = GameObject.Find("BGAudio");
        song = music.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")){
            if (isPaused)
            {
                Resume();
            }
            else
            {
                song.Pause();
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        song.UnPause();
    }
}
