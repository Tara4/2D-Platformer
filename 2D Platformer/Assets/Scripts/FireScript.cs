using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").GetComponent<PlayerScript>().phase2 == true)
        {
            speed = 10;
        }

        else if(GameObject.Find("Player").GetComponent<PlayerScript>().phase3 == true)
        {
            speed = 15;
        }

        transform.Translate(-2 * Time.deltaTime * speed, 0,0);
    }
}
