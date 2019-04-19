using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    GameObject player;
    private AudioSource sound;

    public int score;
    public int lives;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            if (Instance != this)
            Destroy(this.gameObject);
    }
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
        sound = this.GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        scoreText = scoreGO.GetComponent<Text>();
        scoreText.text = "0";
        livesText = livesGO.GetComponent<Text>();
        livesText.text = "3";
        music = GameObject.Find("BGAudio");
        newName = PlayerPrefs.GetString("Name");
    }
    private void Update()
    {
        Debug.Log("time = " + Time.time);
    }

    // Update is called once per frame
    public void StartAudio()
    {
        song = music.GetComponent<AudioSource>();
        song.volume = 1;
        song.PlayOneShot(song.clip);

    }
    public void startRespawn()
    {
        StartCoroutine(respawn());
    }
    public void startDie()
    {
        StartCoroutine(die());
    }
    public IEnumerator respawn()
    {
        Debug.Log("respawning");

        player.SetActive(false);
        sound.PlayOneShot(sound.clip);
        yield return new WaitForSeconds(2f);
        Debug.Log("respawning2");
        player.SetActive(true);
        player.transform.position = new Vector3(-7.62f, 0, 0);
        player.transform.rotation = Quaternion.identity;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

    }
    public IEnumerator die()
    {
        Debug.Log("dying");
        Destroy(player);
        sound.PlayOneShot(sound.clip);
        yield return new WaitForSeconds(2f);

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
        if (newLives < 1)
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
