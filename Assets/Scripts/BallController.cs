using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Vector3 reset;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        reset = new Vector3(0, 6.5f, 0);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(2f, 3f), 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.name);
        if(collision.transform.name == "floor" || collision.transform.name == "boundary1" || collision.transform.name == "boundary2")
        {
            this.transform.position = reset;
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(Random.Range(2f, 3f), 0, 0));
        }
    }
}
