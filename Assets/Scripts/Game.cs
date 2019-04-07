using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    GameObject music;
    string newName;
    private AudioSource song;
    int newScore;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        GameObject livesGO = GameObject.Find("Lives");
        scoreText = scoreGO.GetComponent<Text>();
        scoreText.text = "0";
        livesText = livesGO.GetComponent<Text>();
        livesText.text = "3";
        music = GameObject.Find("BGAudio");
        newName = PlayerPrefs.GetString("Name");
    }

    // Update is called once per frame
    public void StartAudio()
    {
        song = music.GetComponent<AudioSource>();
        song.volume = 1;
        song.PlayOneShot(song.clip);

    }
    public void ScoreUpdate(int score)
    {
        newScore = int.Parse(scoreText.text); // get current score
        newScore += score; // add 100 points to the score
        scoreText.text = newScore.ToString();
    }
    public void LifeUpdate()
    {
        int newLives = int.Parse(livesText.text); // get current lives
        newLives -= 1; // subtract from the lives
        livesText.text = newLives.ToString();
        if (newLives < 0)
        {
            AddScore();
            SceneManager.LoadScene("Game Over");
        }
    }
    public void AddScore()
    {
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                if (PlayerPrefs.GetInt(i + "HScore") < newScore)
                {
                    // new score is higher than the stored score
                    int oldScore = PlayerPrefs.GetInt(i + "HScore");
                    string oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetInt(i + "HScore", newScore);
                    PlayerPrefs.SetString(i + "HScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                    int j = i + 1;
                    while (j < 10)
                    {
                        oldScore = PlayerPrefs.GetInt(j + "HScore");
                        oldName = PlayerPrefs.GetString(j + "HScoreName");
                        PlayerPrefs.SetInt(j + "HScore", newScore);
                        PlayerPrefs.SetString(j + "HScoreName", newName);
                        newScore = oldScore;
                        newName = oldName;
                        j++;
                    }
                    break;
                }
            }
            else
            {
                PlayerPrefs.SetInt(i + "HScore", newScore);
                PlayerPrefs.SetString(i + "HScoreName", newName);
                break;
            }
        }

    }
}
