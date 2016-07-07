using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	Transform target;

	public bool trackPlayer;
	public float distance;

	void Start ()
	{
		target = GameObject.FindWithTag("Player").transform;
	}

	void FixedUpdate ()
	{
		if (trackPlayer)
		{
			transform.position = new Vector3(
			target.position.x,
			distance,
			target.position.z
			);
		}
	}
}
