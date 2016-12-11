using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room : MonoBehaviour {
    public GameObject WeaponPlace;

    public GameObject Arma1;
    public GameObject Arma2;
    public GameObject Arma3;

    private int[,] espacos;

    // Use this for initialization
    void Start() {

        espacos = new int[,]
        { 
            { 0,0,0,0,0},
            { 0,0,0,0,0},
            { 0,0,0,0,0},
            { 0,0,0,0,0},
            { 0,0,0,0,0}
        };


        for (int arrayNumber = 0; arrayNumber < 5; arrayNumber++)
        {
            for (int objId = 0; objId < 5; objId++)
            {
                switch (espacos[arrayNumber, objId])
                {
                    case 0:
                        Debug.Log("Foi");
                        Instantiate(WeaponPlace,
                            new Vector3(this.transform.position.x + (5 * arrayNumber) - 20,this.transform.position.y,
                                        this.transform.position.z + (5 * objId) - 20), Quaternion.identity);
                        break;
                    case 1:
                        //Debug.Log("Arma 1 na linha : " + arrayNumber + " e pos: " + objId);
                        break;
                    case 2:
                        //Debug.Log("Arma 2 na linha : " + arrayNumber + " e pos: " + objId);
                        break;
                    case 3:
                        //Debug.Log("Arma 3 na linha : " + arrayNumber + " e pos: " + objId);
                        break;
                    default:
                        //Debug.Log("Deu merda bixo");
                        break;
                }
            }
        }

    }
	
	// Update is called once per frame
	void Update () {

    }

    void placeObject(int objectId, int horizontal, int vertical)
    {
        if(this.espacos[horizontal,vertical] == 0)
        {
            this.espacos[horizontal, vertical] = objectId;
        }
    }

    int getObjectId(int horizontal, int vertical) {
        return this.espacos[horizontal, vertical];
    }

    void removeObject(int horizontal, int vertical) {
        this.espacos[horizontal, vertical] = 0;
    }

}
