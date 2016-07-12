using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	Sound sound;
	Movement movement;
	bool firing;

	public GameObject projectilePrefab;
	public float cooldown;
	public float recoil;

	void Awake ()
	{
		sound = GetComponent<Sound>();
		movement = transform.parent.GetComponent<Movement>();
	}

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
			sound.Fire();
			IncreaseShotCount();
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
		movement.ProcessMove(recoil);
	}

	void IncreaseShotCount ()
	{
		GameObject.FindWithTag("GameManager").GetComponent<GameManager>().UpdateShots(1);
	}

	IEnumerator CooldownCoroutine ()
	{
		yield return new WaitForSeconds(cooldown);
		firing = false;
	}
}
