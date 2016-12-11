using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private int actualTurn;
    private bool turnActive;
     

    public int turns;
    public int enemyPerTurn;
    public int minInterval;
    public int maxInterval;
    public EnemySpawn spawn;
    public Room room;

    // Use this for initialization
    void Start () {
        this.actualTurn = 0;
        this.turnActive = false;
        //spawn.spawnEnemy();	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0 && this.turnActive) {
            this.stopTurn();
        };
    }

    int getActualTurn() {
        return this.actualTurn;
    }

    public void nextTurn() {
        spawn.spawnEnemy();
        this.turnActive = true;
        this.actualTurn++;
        room.hideSpots();
    }

    void stopTurn() {
        this.turnActive = false;
        room.showSpots();
    }



}
