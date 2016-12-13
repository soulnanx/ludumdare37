using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusic : MonoBehaviour {

    static bool AudioBegin = false;
    private static BGMusic instance = null;
    private bool nojogo = false;

    public AudioClip inGame;

    public static BGMusic Instance {
           get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        if (!AudioBegin)
        {
            PlayerPrefs.SetInt("tutorial", 1);
            PlayerPrefs.SetInt("efeitos", 1);
            PlayerPrefs.SetInt("musica", 1);
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().name == "MainGame" && !nojogo)
        {
            //GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = inGame;
            GetComponent<AudioSource>().Play();
            nojogo = true;
            //AudioBegin = false;
        }
    }
}
