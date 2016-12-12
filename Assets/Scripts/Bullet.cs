using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public int damage;


    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            collision.GetComponent<Enemy>().life -= this.damage;
            if (this.damage == 0)
            {
                collision.GetComponent<Enemy>().slow = true;
            }
            Object.Destroy(this.gameObject);
        }
    }
}
