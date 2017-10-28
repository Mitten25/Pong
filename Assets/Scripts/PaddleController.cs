using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    private Rigidbody rb;
    public bool inhit;

    public float speed;
    public float hit_force;
    public float drop_speed;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        //movement
        float translation = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector3(translation, 0, 0) * speed);

        //hit
        //float hit = Input.GetAxis("Jump");
        //print(hit);
        //rb.AddForce(new Vector3(0, hit, 0) * hitforce);
        if (Input.GetAxis("Jump") > 0 && inhit == false)
        {
            inhit = true;
            rb.AddForce(new Vector3(0, Input.GetAxis("Jump"), 0) * hit_force);
        }
        if (inhit == true)
        {
            rb.AddForce(new Vector3(0, -1, 0) * drop_speed);
            if (rb.transform.position.y < 0)
                inhit = false;
        }
        else
        {
            rb.transform.position = new Vector3(rb.transform.position.x, 0, rb.transform.position.y);
        }



	}
}
