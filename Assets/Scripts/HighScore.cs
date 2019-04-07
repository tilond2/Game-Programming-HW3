using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public int num;
    Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
        int score = PlayerPrefs.GetInt(num + "HScore");
        string name = PlayerPrefs.GetString(num + "HScoreName");
        t.text = name + $" : {score}";
    }
}
