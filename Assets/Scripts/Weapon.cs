using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject projectilePrefab;
	public Transform spawnPoint;

	public void RecieveFireInput ()
	{
		Fire();
	}

	void Fire ()
	{
		GameObject projectile = (GameObject)Instantiate(
			projectilePrefab,
			spawnPoint.position,
			spawnPoint.rotation
		);
		projectile.GetComponent<Projectile>().Fire(transform.forward);
	}
}
