using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public Enemy enemy1;
    public Enemy enemy2;
    public Enemy enemy3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void spawnEnemy() {
        int enemy = (int) System.Math.Ceiling(Random.Range(0f, 3f));
        switch (enemy) {
            case 1:
                Instantiate(enemy1, this.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemy2, this.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(enemy3, this.transform.position, Quaternion.identity);
                break;
            default:
                Debug.Log("Deu merda bixo");
                break;
        }
        Debug.Log(enemy);
    }


}
