using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject projectilePrefab;
	public Transform spawnPoint;
	public float recoil;

	public void RecieveFireInput ()
	{
		Fire();
	}

	void Recoil ()
	{
		transform.parent.GetComponent<Rigidbody>().AddForce(-transform.forward * recoil);
	}

	void Fire ()
	{
		GameObject projectile = (GameObject)Instantiate(
			projectilePrefab,
			spawnPoint.position,
			spawnPoint.rotation
		);

		Recoil();
		projectile.GetComponent<Projectile>().Fire(transform.forward);
	}
}
