using UnityEngine;
using System.Collections;

public class GraveSpawner : Spawner
{
	public Transform bounds;

	public override void Spawn ()
	{
		Instantiate(spawnPrefab, RandomLocation(), transform.rotation);
	}

	Vector3 RandomLocation ()
	{
		float xRange = (bounds.localScale.x / 2) - 0.5f;
		float zRange = (bounds.localScale.z / 2) - 0.5f;
		return new Vector3(
			Mathf.Round(Random.Range(-xRange, xRange)),
			0.5f,
			Mathf.Round(Random.Range(-zRange, zRange))
		);
	}
}
