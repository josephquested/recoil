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
		ActivateAgent();
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
		agent = GetComponent<NavMeshAgent>();
		if (agent != null)
		{
			GameObject player = GameObject.FindWithTag("Player");
			if (player != null)
			{
				goal = player.transform;
				agent.enabled = true;
			}
		}
	}

	void UpdateAgent ()
	{
		if (goal != null)
		{
			agent.destination = goal.position;
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
