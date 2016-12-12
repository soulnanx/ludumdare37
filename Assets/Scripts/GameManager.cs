using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    private int actualTurn;
    private bool turnActive;

    private int activeWeapon;

    public int turns;
    public int enemyPerTurn;
    public int minInterval;
    public int maxInterval;
    public int vidas;
    public int blocksDinheiro;
    public EnemySpawn spawn;
    public Room room;

    public Text waves;
    public TextAsset jsonFile;
    public Text blocksText;
    public Text lifeText;
    public Waves[] waveList = new Waves[8];

    public GameObject gameOver;

    [System.Serializable]
    private class WaveList
    {
        public List<Waves> waves;
    }

    private bool generating = false;

    // Use this for initialization
    void Start () {
        this.blocksDinheiro = 4;
        this.vidas = 20;
        this.actualTurn = 0;
        this.turnActive = false;
        this.activeWeapon = 2;
        //spawn.spawnEnemy();


        WaveList wl = new WaveList();
        JsonUtility.FromJsonOverwrite(jsonFile.text, wl);
        waveList = wl.waves.ToArray();

    }
	
	// Update is called once per frame
	void Update () {
        waves.text = "WAVE " + this.actualTurn;
        blocksText.text = ""+this.blocksDinheiro;
        lifeText.text = ""+this.vidas;
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && (this.turnActive && !this.generating)) {
            this.blocksDinheiro += waveList[this.actualTurn - 1].bounty;
            this.stopTurn();
        };

        if (vidas <= 0) {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    int getActualTurn() {
        return this.actualTurn;
    }

    private int getEnemyType(string type)
    {
        switch (type)
        {
            case "soldier":
                return 3;
            case "doll":
                return 1;
            case "car":
                return 2;
            case "boss":
                return 4;
            default:
                Debug.Log("Deu merda bixo");
                return 0;
        }
    }

    IEnumerator showTextFuntion(int[] quantity, string[] types)
    {
        for (int index = 0; index < types.Length; index++)
        {
            for (int q = 0; q < quantity[index]; q++)
            {
                generating = true;
                Debug.Log("oi");
                spawn.spawnEnemy(getEnemyType(types[index]));
                yield return new WaitForSeconds(3f);
                Debug.Log("Tchau");
                generating = false;
            }

        }
    }

    public void clickMenu(string option) {
        switch (option) {
            case "exit":
                Application.Quit();
                break;
            case "retry":
                SceneManager.LoadScene("MainGame");
                break;
            default:
                break;
        }
    }


    public void nextTurn() {
        if (spawn.canStart() && !this.turnActive)
        {
            Debug.Log("chegou");
            Waves w = waveList[this.actualTurn];
            StartCoroutine(showTextFuntion(w.quantity, w.type));
            this.actualTurn++;
            room.hideSpots();
            this.turnActive = true;
        }
        else {
            Debug.Log("Path is blocked");
        }
    }

    void stopTurn() {
        this.turnActive = false;
        room.showSpots();
    }

    public void changeWeapon(int weapon) {
        this.activeWeapon = weapon;
    }

    public int getWeapon() {
        return this.activeWeapon;
    }

}
