using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	Transform target;
	float distance = 5;

	void Start ()
	{
		target = GameObject.FindWithTag("Player").transform;
	}

	void FixedUpdate ()
	{
		transform.position = new Vector3(
			target.position.x,
			10,
			target.position.z - distance
		);
	}
}
