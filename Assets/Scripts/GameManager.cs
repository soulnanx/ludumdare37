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

    // Use this for initialization
    void Start () {
        this.actualTurn = 0;
        spawn.spawnEnemy();	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindWithTag("Enemy") == null) {
            Debug.Log("No enemys founds");
        };
    }

    int getActualTurn() {
        return this.actualTurn;
    }

    void nextTurn() {
        this.turnActive = true;
        this.actualTurn++;
    }

    void stopTurn() {
        this.turnActive = false;
    }



}
