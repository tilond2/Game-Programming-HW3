using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    GameObject GameManager;
    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D coll)
    {
        if ((coll.gameObject.name!= "Player" || gameObject.tag == "Enemy") && coll.gameObject.name!=gameObject.name)
        {
            if (coll.gameObject.tag != "Enemy")
            {
                GameManager.GetComponent<GameManager>().ScoreUpdate(100);
            }
            Destroy(gameObject);
        }
        
    }
}
