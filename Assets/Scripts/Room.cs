using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room : MonoBehaviour {
    public GameObject WeaponPlace;

    public GameObject Arma1;
    public GameObject Arma2;
    public GameObject Arma3;

    private GameObject[] spots;

    private int[,] espacos = new int[,]
        {
            { 0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0}
        };

    // Use this for initialization
    void Start() {
        for (int arrayNumber = 0; arrayNumber < 9; arrayNumber++)
        {
            for (int objId = 0; objId < 7; objId++)
            {
                GameObject spot = Instantiate(WeaponPlace,
                    new Vector3(this.transform.position.x + (5 * arrayNumber) - 20,this.transform.position.y + 1,
                                this.transform.position.z + (5 * objId) - 17), Quaternion.identity);
                spot.GetComponent<WeaponSpot>().setId(arrayNumber, objId);
            }
        }

        spots = GameObject.FindGameObjectsWithTag("Spot");
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void placeObject(int objectId, int horizontal, int vertical)
    {
        if(this.espacos[horizontal,vertical] == 0)
        {
            this.espacos[horizontal, vertical] = objectId;
            switch (objectId) {
                case 1:
                    Instantiate(Arma1, new Vector3(this.transform.position.x + (5 * horizontal) - 20, this.transform.position.y + 1,
                                this.transform.position.z + (5 * vertical) - 17), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Arma2, new Vector3(this.transform.position.x + (5 * horizontal) - 20, this.transform.position.y + 1,
                                this.transform.position.z + (5 * vertical) - 17), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Arma3, new Vector3(this.transform.position.x + (5 * horizontal) - 20, this.transform.position.y + 1,
                                this.transform.position.z + (5 * vertical) - 17), Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }

    int getObjectId(int horizontal, int vertical) {
        return this.espacos[horizontal, vertical];
    }

    void removeObject(int horizontal, int vertical) {
        this.espacos[horizontal, vertical] = 0;
    }

    public void hideSpots() {
        

        foreach (GameObject spot in spots) {
            spot.SetActive(false);
        }
    }

    public void showSpots()
    {
        foreach (GameObject spot in spots)
        {
            spot.SetActive(true);
        }
    }
}
