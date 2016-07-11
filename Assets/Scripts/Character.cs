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
		while (transform.position.y < 1f)
		{
			transform.Translate(Vector3.up * Time.deltaTime * 20, Space.World);
			yield return null;
		}
		GetComponent<Rigidbody>().isKinematic = false;
	}

	public void RecieveFireInput (bool fire)
	{
		if (fire)
		{
			weapon.RecieveFireInput();
		}
	}
}
