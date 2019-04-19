using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    GameObject GameManager;
    public float speed = 10f, speedDecay = 10f;
    private AudioSource sound, sound2;
    GameObject music;
    private Game gameScript;
    public bool mute = false;
    public int health = 3;
    float invuln = 0f;
    float cooldownTimer = 0;
    public float fireDelay = 0.25f;

    public Weapon CurrentWeapon;
    [System.Serializable]
    public class Weapon
    {
        public GameObject bullet;
        public float fireDelay = 0.25f;

    }
    // Start is called before the first frame update
    void Start()
    {
        sound = this.GetComponent<AudioSource>();
        music = GameObject.Find("BGAudio");
        GameManager = GameObject.Find("GameManager");
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
        //Debug.Log("invuln = " + invuln);
        invuln -= Time.deltaTime;
        cooldownTimer -= Time.deltaTime;
        if (Input.GetKey("space")){
            fire();
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

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Player touched");
        if (coll.gameObject.tag == "Enemy")
        {
            
            if(invuln <= 0)
            {
                health--;
                if (health > 0)
                {
                    GameManager.GetComponent<GameManager>().startRespawn();
                    invuln = 4f;
                }
                else
                {
                    GameManager.GetComponent<GameManager>().startDie();
                    invuln = 2f;
                }
                
                GameManager.GetComponent<GameManager>().LifeUpdate();
                
            }
           
            if (!mute)
            {
                sound.PlayOneShot(sound.clip);
            }
            
        }
    }
    public IEnumerator die()
    {
        Debug.Log("dying");
        Destroy(gameObject);
        yield return new WaitForSeconds(2f);

    }
    public IEnumerator respawn()
    {
        Debug.Log("respawning");

        gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        Debug.Log("respawning2");
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(-7.62f, 0, 0);
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

    }
    public void fire()
    {
        if (cooldownTimer <= 0)
        {
            cooldownTimer = CurrentWeapon.fireDelay;
            
            CurrentWeapon.bullet = Instantiate<GameObject>(bullet);
            CurrentWeapon.bullet.transform.position = transform.position;
            CurrentWeapon.bullet.transform.rotation = transform.rotation;
            //float x = shot.transform.rotation.eulerAngles;
            CurrentWeapon.bullet.transform.rotation *= Quaternion.Euler(0, 0, -90f);
            GameObject shot = CurrentWeapon.bullet;
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
