using UnityEngine;
using System.Collections;

public class GraveSpawner : Spawner
{
	public Transform bounds;

	public override void Spawn ()
	{
		GameObject grave = (GameObject)Instantiate(
			spawnPrefab,
			RandomLocation(),
			spawnPrefab.transform.rotation
		);
		StartCoroutine(SpawnCoroutine(grave));
	}

	IEnumerator SpawnCoroutine (GameObject grave)
	{
		while (grave.transform.position.y < 1.5f)
		{
			grave.transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
			yield return null;
		}
	}

	Vector3 RandomLocation ()
	{
		float xRange = (bounds.localScale.x / 2) - 1.5f;
		float zRange = (bounds.localScale.z / 2) - 3f;
		return new Vector3(
			Mathf.Round(Random.Range(-xRange, xRange)),
			-2f,
			Mathf.Round(Random.Range(-zRange, zRange))
		);
	}
}
