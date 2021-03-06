﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball3DAgent : Agent
{
	[Header("Specific to Pong")]
	public GameObject ball;
	public float invertMult;

	public override List<float> CollectState()
	{
		List<float> state = new List<float>();
		state.Add(invertMult * gameObject.transform.position.x / 8f);
		state.Add(gameObject.transform.position.y / 2f);
		state.Add(invertMult * gameObject.GetComponent<Rigidbody>().velocity.x / 10f);
		state.Add(gameObject.GetComponent<Rigidbody>().velocity.y / 10f);

		state.Add(invertMult * ball.transform.position.x / 8f);
		state.Add(ball.transform.position.y / 8f);
		state.Add(invertMult * ball.GetComponent<Rigidbody>().velocity.x / 10f);
		state.Add(ball.GetComponent<Rigidbody>().velocity.y / 10f);
		return state;
	}

	// to be implemented by the developer
	public override void AgentStep(float[] act)
	{
		float moveX = 0.0f;
		if (act[0] == 0f)
		{
			moveX = invertMult * -0.25f;
		}
		if (act[0] == 1f)
		{
			moveX = invertMult * 0.25f;
		}
		if (act[0] == 2f)
		{
			moveX = 0.0f;
		}
		if (act[0] == 3f)
		{
			//moveY = 0.5f; // Replace with hit code
		}
		gameObject.transform.position = new Vector3(gameObject.transform.position.x + moveX, gameObject.transform.position.y, 5f);

		if (gameObject.transform.position.x > (invertMult) * 11f)
		{
			gameObject.transform.position = new Vector3(-(invertMult) * 11f, gameObject.transform.position.y, 5f);
		}
		if (gameObject.transform.position.x < (invertMult) * 2f)
		{
			gameObject.transform.position = new Vector3((invertMult) * 2f, gameObject.transform.position.y, 5f);
		}
		
		/*if (gameObject.transform.position.y > -2f)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0f, 5f);
		}*/
	}

	// to be implemented by the developer
	public override void AgentReset()
	{
		invertMult = 1f;
		gameObject.transform.position = new Vector3((invertMult) * 7f, -1.5f, 5f);
		gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
	}
}
