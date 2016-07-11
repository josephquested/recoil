using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour
{
	public float hoverSpeed;

	void Awake ()
	{
		StartCoroutine(Hover(true));
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.CompareTag("Player"))
		{
			// level controller do something
			Destroy(gameObject);
		}
	}

	IEnumerator Hover (bool up)
	{
		if (up)
		{
			while (transform.position.y < 1.2f)
			{
				transform.Translate(Vector3.up * Time.deltaTime * hoverSpeed, Space.World);
				yield return null;
			}
			StartCoroutine(Hover(false));
		}
		else
		{
		 	while (transform.position.y > 1f)
			{
				transform.Translate(Vector3.down * Time.deltaTime * hoverSpeed, Space.World);
				yield return null;
			}
			StartCoroutine(Hover(true));
		}
	}
}
