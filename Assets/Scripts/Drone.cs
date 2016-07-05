using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	NavMeshAgent agent;
	Transform goal;

	void Awake ()
	{
		agent = GetComponent<NavMeshAgent>();
		goal = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void FixedUpdate ()
	{
		if (agent != null)
		{
			UpdateAgent();
		}
	}

	void UpdateAgent ()
	{
		if (goal != null)
		{
			agent.destination = goal.position;
		}
		else
		{
			agent.destination = Vector3.zero;
		}
	}

	void OnCollisionStay (Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			// collision.gameObject.BroadcastMessage("Damage", 0.1f);
		}
	}
}
