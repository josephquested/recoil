using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	Rigidbody rb;
	public float speed;

	void Awake ()
	{
		rb = GetComponent<Rigidbody>();
		Destroy(gameObject, 5f);
	}

	public void Fire (Vector3 heading)
	{
		rb.AddForce(transform.forward * speed);
	}
}
