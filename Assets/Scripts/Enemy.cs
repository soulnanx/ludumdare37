using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject objetivo;
    public float speed;
	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, objetivo.transform.position, step);		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == objetivo.tag) {
            Object.Destroy(this.gameObject);
        }
    }
}
