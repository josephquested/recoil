using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject projectilePrefab;
	public float recoil;

	public void RecieveFireInput ()
	{
		Fire();
	}

	void Recoil ()
	{
		Rigidbody rb = transform.parent.GetComponent<Rigidbody>();
		if (rb != null) rb.AddForce(-transform.forward * recoil);
	}

	void Fire ()
	{
		GameObject projectile = (GameObject)Instantiate(
			projectilePrefab,
			transform.position,
			transform.rotation
		);

		Recoil();
		projectile.GetComponent<Projectile>().Fire(transform.forward);
	}
}
