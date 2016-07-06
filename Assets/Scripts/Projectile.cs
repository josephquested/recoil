using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	Rigidbody rb;

	public float speed;
	public int damage;

	void Awake ()
	{
		rb = GetComponent<Rigidbody>();
		Destroy(gameObject, 5f);
	}

	public void Fire (Vector3 heading)
	{
		rb.AddForce(transform.forward * speed);
	}

	void OnTriggerEnter (Collider collider)
	{
		Health health = collider.gameObject.GetComponent("Health") as Health;
		if (health != null && collider.tag != "Weapon")
		{
			health.Damage(damage);
			Destroy(gameObject);
		}
	}
}
