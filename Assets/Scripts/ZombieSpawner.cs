using UnityEngine;
using System.Collections;

public class ZombieSpawner : Spawner
{
	public Transform bounds;

	public override void Spawn ()
	{
		GameObject zombie = (GameObject)Instantiate(
			spawnPrefab,
			RandomLocation(),
			spawnPrefab.transform.rotation
		);
		StartCoroutine(SpawnCoroutine(zombie));
	}

	IEnumerator SpawnCoroutine (GameObject zombie)
	{
		while (zombie.transform.position.y < 1.1f && zombie != null)
		{
			zombie.transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
			yield return null;
		}
		zombie.GetComponent<Zombie>().ActivateAgent();
	}

	Vector3 RandomLocation ()
	{
		float xRange = (bounds.localScale.x / 2) - 0.5f;
		float zRange = (bounds.localScale.z / 2) - 0.5f;
		return new Vector3(
			Mathf.Round(Random.Range(-xRange, xRange)),
			-2f,
			Mathf.Round(Random.Range(-zRange, zRange))
		);
	}
}
