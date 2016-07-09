using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject projectilePrefab;
	public float recoil;
	public float cooldown;

	bool firing;

	public void RecieveFireInput ()
	{
		ProcessFire();
	}

	void ProcessFire ()
	{
		if (!firing) {
			firing = true;
			Fire();
			Recoil();
			StartCoroutine(CooldownCoroutine());
		}
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

	void Recoil ()
	{
		Rigidbody rb = transform.parent.GetComponent<Rigidbody>();
		if (rb != null) rb.AddForce(-transform.forward * recoil);
	}

	IEnumerator CooldownCoroutine ()
	{
		yield return new WaitForSeconds(cooldown);
		firing = false;
	}
}
