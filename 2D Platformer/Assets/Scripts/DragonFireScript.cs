using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireScript : MonoBehaviour
{
    public int fireSpeed;

    //Connect prefab to spawner
    public GameObject firePrefab; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnFire", 0, 1);
    }

    void spawnFire()
    {
        if(GameObject.Find("Player").GetComponent<PlayerScript>().dragonHit == false)
        {
            //Generate z spawn point
            Vector2 pos = new Vector2(1, 0);
            transform.position = pos;

            //Create fireball
            GameObject fire = Instantiate(firePrefab, transform.position, Quaternion.identity);

            //Send the fireball
           fire.GetComponent<Rigidbody2D>().velocity = Vector2.left * fireSpeed;

           //Destory fireball
           Destroy(fire, 3);
        }
    }
}
