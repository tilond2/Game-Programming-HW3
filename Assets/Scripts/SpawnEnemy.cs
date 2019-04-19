using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyPrefab;
    public float seconds = 1f;
    void Start()
    {
        Debug.Log("Seconds =: " + seconds);
        StartCoroutine(Spawn());

    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            GameObject enemy = Instantiate(EnemyPrefab);
            enemy.transform.position = new Vector3(8.9f, Random.Range(-5f, 5f), 0);
            enemy.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180f, 180f));
        }
            
    }
}
