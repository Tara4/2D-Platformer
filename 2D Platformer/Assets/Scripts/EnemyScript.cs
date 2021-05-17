using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public bool moveRight;

    void Update()
    {
        if(moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2(4,4);
        }

        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2(-4,4);
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Turn"))
        {
            if(moveRight)
            {
                moveRight = false;
            }

            else
            {
                moveRight = true;
            }
        }

        else if(trig.gameObject.CompareTag("Sword"))
        {
            Destroy(gameObject);
        }
    }
}
