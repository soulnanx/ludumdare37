using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public Text blocksText;
    public Text lifeText;
    public Waves[] waveList = new Waves[8];

    // Use this for initialization
    void Start () {
        this.blocksDinheiro = 4;
        this.vidas = 20;
        this.actualTurn = 0;
        this.turnActive = false;
        this.activeWeapon = 2;
        //spawn.spawnEnemy();

        waveList[0] = new Waves();
        waveList[0].type = new string[] { "soldier" };
        waveList[0].quantity = new int[] { 1 };

        waveList[1] = new Waves();
        waveList[1].type = new string[] { "soldier" };
        waveList[1].quantity = new int[] { 3 };
        
        waveList[2] = new Waves();
        waveList[2].type = new string[] { "soldier" };
        waveList[2].quantity = new int[] { 6 };
        
        waveList[3] = new Waves();
        waveList[3].type = new string[] { "soldier" };
        waveList[3].quantity = new int[] { 10 };
        
        waveList[4] = new Waves();
        waveList[4].type = new string[] { "doll" };
        waveList[4].quantity = new int[] { 2 };
        
        waveList[5] = new Waves();
        waveList[5].type = new string[] { "car" };
        waveList[5].quantity = new int[] { 5 };
        

    }
	
	// Update is called once per frame
	void Update () {
        waves.text = "WAVE " + this.actualTurn;
        blocksText.text = ""+this.blocksDinheiro;
        lifeText.text = ""+this.vidas;
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && this.turnActive) {
            this.stopTurn();
        };
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
                Debug.Log("oi");
                spawn.spawnEnemy(getEnemyType(types[index]));
                yield return new WaitForSeconds(3f);
                Debug.Log("Tchau");
            }

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
