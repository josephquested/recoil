using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Goal : MonoBehaviour
{
	GameManager gameManager;
	public List<GameObject> orbIcons = new List<GameObject>();

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
			orbIcons.Add(icon);
			yield return new WaitForSeconds(delay);
		}
	}

	public void OrbCollected ()
	{
		Destroy(orbIcons[0]);
		orbIcons.RemoveAt(0);
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
