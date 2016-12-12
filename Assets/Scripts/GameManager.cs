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

        Waves wave1 = new Waves();
        wave1.type = new string[] { "soldier" };
        wave1.quantity = new int[] { 1 };
        waveList[0] = wave1;

        Waves wave2 = new Waves();
        wave2.type = new string[] { "soldier" };
        wave2.quantity = new int[] { 3 };
        waveList[1] = wave2;

        Waves wave3 = new Waves();
        wave3.type = new string[] { "soldier" };
        wave3.quantity = new int[] { 6 };
        waveList[2] = wave3;

        Waves wave4 = new Waves();
        wave4.type = new string[] { "soldier" };
        wave4.quantity = new int[] { 10 };
        waveList[3] = wave4;

        Waves wave5 = new Waves();
        wave1.type = new string[] { "doll" };
        wave1.quantity = new int[] { 2 };
        waveList[4] = wave5;

        Waves wave6 = new Waves();
        wave6.type = new string[] { "car" };
        wave6.quantity = new int[] { 5 };
        waveList[5] = wave6;
        

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


    IEnumerator showTextFuntion(int[] quantity, string[] types)
    {
        for (int index = 0; index < types.Length; index++)
        {
            switch (types[index])
            {
                case "soldier":
                    for (int q = 0; q <= quantity[index]; q++)
                    {
                        Debug.Log("oi");
                        spawn.spawnEnemy(1);
                        yield return new WaitForSeconds(3f);
                        Debug.Log("Tchau");
                    }
                    break;
                case "doll":
                    for (int q = 0; q <= quantity[index]; q++)
                    {
                        Debug.Log("oi");
                        spawn.spawnEnemy(3);
                        yield return new WaitForSeconds(3f);
                        Debug.Log("Tchau");
                    }
                    break;
                case "car":
                    for (int q = 0; q <= quantity[index]; q++)
                    {
                        Debug.Log("oi");
                        spawn.spawnEnemy(2);
                        yield return new WaitForSeconds(3f);
                        Debug.Log("Tchau");
                    }
                    break;
                default:
                    Debug.Log("Deu merda bixo");
                    break;
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
