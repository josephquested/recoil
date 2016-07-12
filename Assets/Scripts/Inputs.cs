using UnityEngine;
using System.Collections;

public class Inputs : MonoBehaviour
{
	Player character;

	void Awake ()
	{
		character = GetComponent<Player>();
	}

	void FixedUpdate ()
	{
		CursorInput();
		FireInput();
	}

	void FireInput ()
	{
		character.RecieveFireInput(Input.GetButtonDown("Fire1"));
	}

	void CursorInput ()
	{
  	Plane playerPlane = new Plane(Vector3.up, transform.position);
  	Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
  	float hitdist = 0.0f;
  	if (playerPlane.Raycast (ray, out hitdist))
		{
    	Vector3 targetPoint = ray.GetPoint(hitdist);
    	Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			ControlRotation(Quaternion.Slerp(transform.rotation, targetRotation, 100 * Time.deltaTime));
		}
	}

	void ControlRotation (Quaternion rotation)
	{
		float y = rotation.eulerAngles.y;
		if (y >= 337.5 || y < 22.5)
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		if (y >= 22.5 && y < 67.5)
		{
			transform.eulerAngles = new Vector3(0, 45, 0);
		}
		if (y >= 67.5 && y < 112.5)
		{
			transform.eulerAngles = new Vector3(0, 90, 0);
		}
		if (y >= 112.5 && y < 157.5)
		{
			transform.eulerAngles = new Vector3(0, 135, 0);
		}
		if (y >= 157.5 && y < 202.5)
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
		if (y >= 202.5 && y < 247.5)
		{
			transform.eulerAngles = new Vector3(0, 225, 0);
		}
		if (y >= 247.5 && y < 292.5)
		{
			transform.eulerAngles = new Vector3(0, 270, 0);
		}
		if (y >= 292.5 && y < 337.5)
		{
			transform.eulerAngles = new Vector3(0, 315, 0);
		}
	}
}
