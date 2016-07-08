using UnityEngine;
using System.Collections;

public class Zombie : Character
{
	NavMeshAgent agent;
	Transform goal;

	public float damage;

	public override IEnumerator AwakeCoroutine ()
	{
		while (transform.position.y < 1f)
		{
			transform.Translate(Vector3.up * Time.deltaTime * 4, Space.World);
			yield return null;
		}
		GetComponent<Zombie>().ActivateAgent();
	}

	void FixedUpdate ()
	{
		if (agent != null)
		{
			UpdateAgent();
		}
	}

	public void ActivateAgent ()
	{
		if (GameObject.FindGameObjectWithTag("Player") != null)
		{
			agent = GetComponent<NavMeshAgent>();
			goal = GameObject.FindGameObjectWithTag("Player").transform;
			agent.enabled = true;
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
