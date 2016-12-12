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

    public bool spawnEnemy() {
        int enemy = (int) System.Math.Ceiling(Random.Range(0f, 3f));
        switch (enemy) {
            case 1:
                Enemy e1 = Instantiate(enemy1, this.transform.position, Quaternion.identity);
                if (e1.pathIsClear())
                    return true;
                break;
            case 2:
                Enemy e2 = Instantiate(enemy2, this.transform.position, Quaternion.identity);
                if (e2.pathIsClear())
                    return true;
                break;
            case 3:
                Enemy e3 = Instantiate(enemy3, this.transform.position, Quaternion.identity);
                if (e3.pathIsClear())
                    return true;
                break;
            default:
                Debug.Log("Deu merda bixo");
                return false;
        }
        Debug.Log(enemy);
        return false;
        
    }
}
