using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public bool tutorial = true;
    public bool musica = true;
    public bool efeitos = true;
    

    public void setTutorial(bool state) {
        this.tutorial = state;
    }

    public void setMusica(bool state)
    {
        this.musica = state;
    }

    public void setEfeitos(bool state)
    {
        this.efeitos = state;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape") && SceneManager.GetActiveScene().name != "MainGame")
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
            case "menu":
                SceneManager.LoadScene("Menu");
                break;
            default:
                break;            
        }
    }

}
