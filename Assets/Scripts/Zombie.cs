using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
	NavMeshAgent agent;
	Transform goal;

	public float damage;

	public void ActivateAgent ()
	{
		if (GameObject.FindGameObjectWithTag("Player") != null)
		{
			agent = GetComponent<NavMeshAgent>();
			goal = GameObject.FindGameObjectWithTag("Player").transform;
			agent.enabled = true;
		}
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
		else if (agent != null)
		{
			agent.destination = transform.position;
		}
	}

	void OnCollisionStay (Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<Health>().Damage(damage);
		}
	}
}
