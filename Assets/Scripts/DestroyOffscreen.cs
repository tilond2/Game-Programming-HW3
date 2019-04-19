using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{
    public WrapAround script;
    // Start is called before the first frame update
    void Start()
    {
        WrapAround script = gameObject.GetComponent<WrapAround>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.wrap()) 
        {
            Destroy(gameObject);
        }
    }
}
