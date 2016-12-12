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

    public bool canStart() {
        Enemy e1 = Instantiate(enemy1, this.transform.position, Quaternion.identity);
        if (e1.pathIsClear()){
            Object.Destroy(e1.gameObject);
            return true;
        } else {
            Object.Destroy(e1.gameObject);
            return false;
        }

    }

    public void spawnEnemy(int enemy) {
        switch (enemy) {
            case 1:
                Enemy e1 = Instantiate(enemy1, this.transform.position, Quaternion.identity);
                break;
            case 2:
                Enemy e2 = Instantiate(enemy2, this.transform.position, Quaternion.identity);
                break;
            case 3:
                Enemy e3 = Instantiate(enemy3, this.transform.position, Quaternion.identity);
                break;
            default:
                Debug.Log("Deu merda bixo");
                break;
        }
        Debug.Log(enemy);        

    }
}
