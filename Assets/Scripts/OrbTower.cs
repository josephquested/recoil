using UnityEngine;
using System.Collections;

public class OrbTower : MonoBehaviour
{
	public GameObject orb;
	public float glowSpeed;

	void Awake ()
	{
		// StartCoroutine(Glow(true));
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.CompareTag("Projectile"))
		{
			GameObject.FindWithTag("Goal").GetComponent<Goal>().OrbCollected();
			Destroy(collider.gameObject);
			DeactivateOrb();
		}
	}

	void DeactivateOrb ()
	{
		orb.GetComponent<Renderer>().material.color = Color.black;
	}

	// IEnumerator Glow (bool up)
	// {
	// 	if (up)
	// 	{
	// 		while (transform.position.y < 1.2f)
	// 		{
	// 			transform.Translate(Vector3.up * Time.deltaTime * hoverSpeed, Space.World);
	// 			yield return null;
	// 		}
	// 		StartCoroutine(Hover(false));
	// 	}
	// 	else
	// 	{
	// 	 	while (transform.position.y > 1f)
	// 		{
	// 			transform.Translate(Vector3.down * Time.deltaTime * hoverSpeed, Space.World);
	// 			yield return null;
	// 		}
	// 		StartCoroutine(Hover(true));
	// 	}
	// }
}
