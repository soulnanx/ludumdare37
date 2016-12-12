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
    public TextAsset jsonFile;
    public Text blocksText;
    public Text lifeText;
    public Waves[] waveList = new Waves[8];

    [System.Serializable]
    private class WaveList
    {
        public List<Waves> waves;
    }
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
        if (spawn.canStart())
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
