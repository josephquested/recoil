using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	GameManager gm;
	Transform bounds;
	bool cooling;

	public Transform spawnPoint;
	public GameObject spawnPrefab;
	public float spawnCooldown;

	void Awake ()
	{
		gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
		bounds = GameObject.FindWithTag("Bounds").transform;
		StartCoroutine(AwakeCoroutine());
	}

	IEnumerator AwakeCoroutine ()
	{
		while (transform.position.y < 1.5f)
		{
			transform.Translate(Vector3.up * Time.deltaTime * 4, Space.World);
			yield return null;
		}
	}

	void Update ()
	{
		if (!cooling && gm.gameActive)
		{
			StartCoroutine(SpawnCoroutine());
		}
	}

	IEnumerator SpawnCoroutine ()
	{
		cooling = true;
		yield return new WaitForSeconds(spawnCooldown);
		cooling = false;
		ProcessSpawn();
	}

	void ProcessSpawn ()
	{
		Vector3 location;

		if (spawnPoint == null)
		{
			location = RandomLocation();
		}
		else
		{
			location = spawnPoint.position;
		}

		Spawn(location);
	}

	void Spawn (Vector3 location)
	{
		Instantiate(spawnPrefab, location, spawnPrefab.transform.rotation);
	}

	Vector3 RandomLocation ()
	{
		float xRange = (bounds.localScale.x / 2) - 2f;
		float zRange = (bounds.localScale.z / 2) - 3f;

		return new Vector3(
			Mathf.Round(Random.Range(-xRange, xRange)),
			-2f,
			Mathf.Round(Random.Range(-zRange, zRange))
		);
	}
}
