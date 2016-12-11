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


    // Use this for initialization
    void Start () {

        this.actualTurn = 0;
        this.turnActive = false;
        this.activeWeapon = 2;
        //spawn.spawnEnemy();	
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

    public void nextTurn() {
        if (spawn.spawnEnemy())
        {
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
