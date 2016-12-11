using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    private GameObject objetivo;
    public float speed;

	// Use this for initialization
	void Start () {
        objetivo = GameObject.FindGameObjectsWithTag("Bau")[0];

    }
	
	// Update is called once per frame
	void Update () {
        //objetivo = GameObject.FindGameObjectsWithTag("Bau")[0];
        float step = speed * Time.deltaTime;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = objetivo.transform.position;
        //transform.rotation = Quaternion.LookRotation(dir);
        //transform.position = Vector3.MoveTowards(transform.position, objetivo.transform.position, step);
        //transform.LookAt(objetivo.transform.position, transform.up);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bau") {
            Object.Destroy(this.gameObject);
        }
    }
}
