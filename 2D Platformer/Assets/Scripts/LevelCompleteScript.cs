using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelCompleteScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collide)
    {
        if(collide.gameObject.tag == "Player")
        {
            print("test");
            Scene currentScene = SceneManager.GetActiveScene();
            if(currentScene.name == "Level 1")
            {
                SceneManager.LoadScene("Level 2");
            }

            else if(currentScene.name == "Level 2")
            {
                SceneManager.LoadScene("Level 3");
            }
        }        
    }
}
