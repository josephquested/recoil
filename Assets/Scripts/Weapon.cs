using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject projectilePrefab;

	public void RecieveFireInput ()
	{
		Fire();
	}

	void Fire ()
	{
		GameObject projectile = (GameObject)Instantiate(
			projectilePrefab,
			transform.position,
			transform.rotation
		);
		projectile.GetComponent<Projectile>().Fire(transform.forward);
	}
}
