using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void buttonClick(string button)
    {
        switch (button) {
            case "start":
                SceneManager.LoadScene("MainGame");
                break;
            case "options":
                SceneManager.LoadScene("Options");
                break;
            case "quit":
                Application.Quit();
                break;
            case "credits":
                SceneManager.LoadScene("Credits");
                break;
            default:
                break;            
        }
    }

}
