using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	GameManager gameManager;
	Movement movement;

	public bool active;
	public Weapon weapon;

	void Awake ()
	{
		gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
		active = true;
	}

	public void RecieveFireInput (bool fire)
	{
		if (fire && active && !movement.moving && movement.IsGrounded())
		{
			weapon.RecieveFireInput();
		}
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.CompareTag("Bounds"))
		{
			active = false;
			gameManager.Lose();
		}
	}
}
