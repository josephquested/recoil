using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	GameManager gm;
	bool cooling;

	public Transform spawnPoint;
	public GameObject spawnPrefab;
	public float spawnCooldown;

	void Awake ()
	{
		gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
		Spawn();
	}

	public virtual void Spawn ()
	{
		Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
