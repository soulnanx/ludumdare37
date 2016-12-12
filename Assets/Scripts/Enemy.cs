using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    private GameObject objetivo;
    private GameManager manager;
    public float speed;

    public int dano;
    public int bounty;
    public int life;

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("GameController").GetComponent<GameManager>();
        objetivo = GameObject.FindGameObjectsWithTag("Bau")[0];
    }
	
	// Update is called once per frame
	void Update () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = new Vector3(objetivo.transform.position.x, objetivo.transform.position.y, objetivo.transform.position.z + 10);
        if (this.life <= 0) {
            manager.GetComponent<GameManager>().blocksDinheiro += this.bounty;
            Object.Destroy(this.gameObject);
        }

    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bau")
        {
            this.manager.vidas = this.manager.vidas - this.dano;
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
        return true;
        
    }
}
