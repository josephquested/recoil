using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	Movement movement;
	public Weapon weapon;

	void Awake ()
	{
		movement = GetComponent<Movement>();
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
