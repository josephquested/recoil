using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Goal : MonoBehaviour
{
	GameManager gameManager;
	List<GameObject> orbIcons = new List<GameObject>();

	public bool locked;
	public GameObject orbIconPrefab;
	public GameObject lockIcon;
	public GameObject iconContainer;

	void Awake ()
	{
		gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
		StartCoroutine(CreateOrbIcons());
		UpdateLock();
	}

	void Update ()
	{
		RotateIcons();
	}

	void UpdateLock ()
	{
		if (orbIcons.Count == 0)
		{
			locked = false;
			Destroy(lockIcon);
		}
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.CompareTag("Player") && !locked)
		{
			collider.GetComponent<Player>().active = false;
			collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
			gameManager.Win();
		}
	}

	public void OrbCollected ()
	{
		Destroy(orbIcons[0]);
		orbIcons.RemoveAt(0);
		UpdateLock();
	}

	IEnumerator CreateOrbIcons ()
	{
		GameObject[] orbs = GameObject.FindGameObjectsWithTag("Orb");
		for (int i = 0; i < orbs.Length; i++)
		{
			GameObject icon = (GameObject)Instantiate(
				orbIconPrefab,
				new Vector3(
					transform.position.x - 1f,
					transform.position.y + 0.2f,
					transform.position.z),
				orbIconPrefab.transform.rotation
			);

			icon.transform.parent = iconContainer.transform;
			orbIcons.Add(icon);
			yield return new WaitForSeconds(0.3f);
		}
	}

	void RotateIcons ()
	{
		iconContainer.transform.Rotate(Vector3.up, Time.deltaTime * 100, Space.World);
	}
}
