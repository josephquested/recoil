using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	Movement movement;
	public Weapon weapon;

	void Awake ()
	{
		movement = GetComponent<Movement>();
		StartCoroutine(AwakeCoroutine());
	}

	public virtual IEnumerator AwakeCoroutine ()
	{
		while (transform.position.y < 2f)
		{
			transform.Translate(Vector3.up * Time.deltaTime * 4, Space.World);
			yield return null;
		}
		GetComponent<Rigidbody>().isKinematic = false;
	}

	public void RecieveMovementInput (float horizontal, float vertial)
	{
		movement.Move(horizontal, vertial);
	}

	public void RecieveFireInput (bool fire1)
	{
		if (fire1)
		{
			weapon.RecieveFireInput();
		}
	}
}
