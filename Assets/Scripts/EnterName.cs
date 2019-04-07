using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nameEntry(string name)
    {
        PlayerPrefs.SetString("Name",name);
    }
}
