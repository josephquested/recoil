using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	bool cooling;

	public Transform spawnPoint;
	public GameObject spawnPrefab;
	public float spawnCooldown;

	void Update ()
	{
		if (!cooling)
		{
			StartCoroutine(SpawnCoroutine());
		}
	}

	IEnumerator SpawnCoroutine ()
	{
		cooling = true;
		yield return new WaitForSeconds(spawnCooldown);
		cooling = false;

		if (GameObject.FindGameObjectWithTag("Player") != null)
		{
			Spawn();
		}
	}

	public virtual void Spawn ()
	{
		Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
