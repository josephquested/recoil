using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	Rigidbody rb;

	public float speed;
	public int damage;
	public float knockback;

	void Awake ()
	{
		rb = GetComponent<Rigidbody>();
		Destroy(gameObject, 5f);
	}

	public void Fire (Vector3 heading)
	{
		rb.AddForce(transform.forward * speed);
	}

	void Knockback (Collider collider)
	{
		Rigidbody rigidbody = collider.gameObject.GetComponent("Rigidbody") as Rigidbody;
		if (rigidbody != null)
		{
			Vector3 direction = rb.velocity;
			collider.gameObject.GetComponent<Rigidbody>().AddForce(direction * knockback);
		}
	}

	void OnTriggerEnter (Collider collider)
	{
		Health health = collider.gameObject.GetComponent("Health") as Health;
		if (health != null && collider.tag != "Weapon")
		{
			health.Damage(damage);
			Knockback(collider);
			Destroy(gameObject);
		}
	}
}
