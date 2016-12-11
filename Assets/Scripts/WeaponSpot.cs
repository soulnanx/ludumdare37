using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpot : MonoBehaviour {
    public Material mouseOver;
    public Material onDefault;
    public GameObject chao;

    private int horizontal;
    private int vertical;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material = mouseOver;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = onDefault;
    }

    private void OnMouseDown()
    {
        Debug.Log("horizontal: " + this.horizontal + " vertical: " + this.vertical);
        chao.GetComponent<Room>().placeObject(1, this.horizontal, this.vertical);
        
    }

    public void setId(int h,int v) {
        this.horizontal = h;
        this.vertical = v;
    }

}
