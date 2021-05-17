using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Button button;
    
	void Start () {
        UnityEngine.UI.Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		SceneManager.LoadScene("Level1");
	}
}
