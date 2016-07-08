using UnityEngine;
using System.Collections;

public class Grave : Spawner
{

	public override void Spawn ()
	{
		GameObject zombie = (GameObject)Instantiate(
			spawnPrefab,
			spawnPoint.position,
			spawnPrefab.transform.rotation
		);
		StartCoroutine(SpawnCoroutine(zombie));
	}

	IEnumerator SpawnCoroutine (GameObject zombie)
	{
		while (zombie.transform.position.y < 1.1f)
		{
			zombie.transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
			yield return null;
		}
		zombie.GetComponent<Zombie>().ActivateAgent();
	}
}
