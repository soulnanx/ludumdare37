using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    public bool tutorial = true;
    public bool musica = true;
    public bool efeitos = true;

    public GameObject musicaCheck;
    public GameObject efeitoCheck;
    public GameObject tutorialCheck;


    public void setTutorial(bool state) {
        this.tutorial = !this.tutorial;
        PlayerPrefs.SetInt("tutorial", this.tutorial ? 1: 0);
    }

    public void setMusica(bool state)
    {
        this.musica = !this.musica;
        PlayerPrefs.SetInt("musica", this.musica ? 1 : 0);
    }

    public void setEfeitos(bool state)
    {
        this.efeitos = !this.efeitos;
        PlayerPrefs.SetInt("efeitos", this.efeitos ? 1 : 0);
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
