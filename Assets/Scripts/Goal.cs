using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
	GameManager gameManager;

	public GameObject orbIconPrefab;
	public float delay;

	void Awake ()
	{
		gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
		StartCoroutine(CreateOrbIcons());
	}

	void Update ()
	{
		Rotate();
		UpdateOrbIcons();
	}

	void Rotate ()
	{
		transform.Rotate(Vector3.up, Time.deltaTime * 100, Space.World);
	}

	IEnumerator CreateOrbIcons ()
	{
		GameObject[] orbs = GameObject.FindGameObjectsWithTag("Orb");
		for (int i = 0; i < orbs.Length; i++)
		{
			Vector3 position = new Vector3(
				transform.position.x - 1f,
				transform.position.y + 0.2f,
				transform.position.z
			);

			GameObject icon = (GameObject)Instantiate(
			orbIconPrefab,
			position,
			orbIconPrefab.transform.rotation
			);

			icon.transform.parent = transform;
			yield return new WaitForSeconds(delay);
		}

		// Add these newly created orbs to a class scoped orbs aray, then in the update
		// orbs icon check to see if the number of orbs has changed in the scene,
		// if it has, remove an orb from orbs array, then, if there are no orbs,
		// the goal is unlocked
	}

	void UpdateOrbIcons ()
	{
		GameObject[] orbs = GameObject.FindGameObjectsWithTag("Orb");
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.CompareTag("Player"))
		{
			collider.GetComponent<Player>().active = false;
			collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
			gameManager.Win();
		}
	}
}
