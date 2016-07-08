using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	Rigidbody rb;
	public float speed;

	void Awake ()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void Move (float horizontal, float vertical)
	{
		if (rb != null)
		{
			Vector3 movement = new Vector3(horizontal, 0, vertical);
			rb.AddForce(movement * speed);
		}
	}
}
