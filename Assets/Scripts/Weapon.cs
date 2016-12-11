using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private int[] id;

    private GameObject GM;
    private GameObject room;
    // Use this for initialization
    void Start () {
        GM = GameObject.Find("GameController");
        room = GameObject.Find("chao");
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] closestEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 currentPosition = transform.position;
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (GameObject potentialTarget in closestEnemy) {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        if (closestEnemy.Length != 0)
        {
            transform.GetChild(0).transform.LookAt(bestTarget.transform.position, transform.up);
        }

    }


    public void setId(int horizontal, int vertical)
    {
        this.id = new int[] { horizontal, vertical };
    }

    public int[] getId() {
        return this.id;
    }

    private void OnMouseUp()
    {
        GM = GameObject.Find("GameController");
        room = GameObject.Find("chao");
        if (GM.GetComponent<GameManager>().getWeapon() == 0) {
            room.GetComponent<Room>().removeObject(this.id[0], this.id[1]);
            Object.Destroy(this.gameObject);
        }
    }


}
