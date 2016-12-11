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
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = objetivo.transform.position;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bau")
        {
            Object.Destroy(this.gameObject);
        }
        else
        {
            Physics.IgnoreCollision(col.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }


    public bool pathIsClear() {
        objetivo = GameObject.FindGameObjectsWithTag("Bau")[0];
        NavMeshPath path = new NavMeshPath();
        GetComponent<NavMeshAgent>().CalculatePath(this.objetivo.transform.position, path);
        Debug.Log(path.status);
        if (path.status == NavMeshPathStatus.PathPartial)
        {
            Object.Destroy(this.gameObject);
            return false;
        }
        else {
            return true;
        }
    }
}
