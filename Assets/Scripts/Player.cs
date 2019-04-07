using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float screenEdge = 9f,speedDecay = 10f;
    private AudioSource sound, sound2;
    GameObject music;
    private Game gameScript;
    public bool mute = false;
    // Start is called before the first frame update
    void Start()
    {
        sound = this.GetComponent<AudioSource>();
        music = GameObject.Find("BGAudio");
        sound2 = music.GetComponent<AudioSource>();
        gameScript = this.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
        {
            Debug.Log("left");
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            Debug.Log("right");
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        float value = Input.GetAxis("Vertical");
        float rotateS = Input.GetAxis("Horizontal")*1.1f;
        float faster = Input.GetAxis("Fire3");
        if (faster != 0) value = value * 1.5f;
        if (value != 0)
        {
            
            
            value = 40f*value / speedDecay;
            transform.Translate(Vector2.up * -value * Time.deltaTime);
        }
        if (rotateS != 0)
            transform.Rotate(Vector3.forward * -rotateS);

        if (transform.position.x > screenEdge)
        {
            transform.position = new Vector3(screenEdge, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -screenEdge) {
            transform.position = new Vector3(-screenEdge, transform.position.y, transform.position.z);
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Player touched");
        if (coll.gameObject.tag == "Fruit")
        {
            gameScript.ScoreUpdate(100);
            if (!mute)
            {
                sound.PlayOneShot(sound.clip);
            }
            
        }
    }
    public void muteSound()
    {
        if (!mute) {
            mute = true;
            sound2.mute = true;
        }
        else {
            mute = false;
            sound2.mute = false;

        };
    }
}
