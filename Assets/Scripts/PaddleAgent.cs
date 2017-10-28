using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAgent : Agent {
    
    public bool inhit;
    public GameObject ball;

    public override List<float> CollectState() {
        return new List<float>();
    }

    public override void AgentStep(float[] act) {
        if (act[0] == 0f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1f, 0f, 0f) * 30);
        }
        if (act[0] == 1f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1f, 0f, 0f) * 30);
        }
        if (act[0] == 2f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 0f));
        }
        if (act[0] == 3f && inhit == false)
        {
            inhit = true;
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 1f, 0f) * 450);
        }

        if (inhit == true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -1, 0) * 20);
            if (gameObject.GetComponent<Rigidbody>().position.y <= 0)
                inhit = false;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().transform.position = new Vector3(gameObject.GetComponent<Rigidbody>().transform.position.x, 0, gameObject.GetComponent<Rigidbody>().transform.position.y);
        }
    }

    public override void AgentReset() {
        gameObject.transform.position = new Vector3(6.23f, 0f, 0f);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
    }
}
