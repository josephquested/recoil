using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	Sound sound;
	bool firing;

	public GameObject projectilePrefab;
	public float recoil;
	public float cooldown;

	void Awake ()
	{
		sound = GetComponent<Sound>();
	}

	public void RecieveFireInput ()
	{
		ProcessFire();
	}

	void ProcessFire ()
	{
		if (!firing) {
			firing = true;
			sound.Fire();
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
