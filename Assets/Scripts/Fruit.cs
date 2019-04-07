using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Set in Inspector")]
    public static float bottomY = -5f;
    public float speed = 1;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position; // get position
        pos.y -=  (Time.deltaTime  * speed); // calculate new position
        transform.position = pos;
        if (transform.position.y < bottomY)
        {
            GameObject player = GameObject.Find("Player");
            Game gameScript = player.GetComponent<Game>();
            gameScript.LifeUpdate();
            Destroy(this.gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Fruit touched");
        if (coll.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            //this.GetComponent<healthScript>().health -= 1;
        }
    }
}
