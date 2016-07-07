using UnityEngine;
using System.Collections;

public class HiveSpawner : Spawner
{
	public Transform bounds;

	public override void Spawn ()
	{
		GameObject hive = (GameObject)Instantiate(
			spawnPrefab,
			RandomLocation(),
			transform.rotation
		);
		StartCoroutine(SpawnCoroutine(hive));
	}

	IEnumerator SpawnCoroutine (GameObject hive)
	{
		while (hive.transform.position.y < 0.5f)
		{
			hive.transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
			yield return null;
		}
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
