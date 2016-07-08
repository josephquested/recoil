using UnityEngine;
using System.Collections;

public class Inputs : MonoBehaviour
{
	Character character;

	void Awake ()
	{
		character = GetComponent<Character>();
	}

	void FixedUpdate ()
	{
		CursorInput();
		MovementInput();
		FireInput();
	}

	void MovementInput ()
	{
		character.RecieveMovementInput(
		Input.GetAxis("Horizontal"),
		Input.GetAxis("Vertical")
		);
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
    	transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100 * Time.deltaTime);
		}
	}
}
