using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	Color defaultColor;
	public float health;

	void Awake ()
	{
		 defaultColor = GetComponent<Renderer>().material.color;
	}

	public void Damage (float damage)
	{
		health -= damage;
		StartCoroutine(FlashCoroutine(0.1f));

		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

	IEnumerator FlashCoroutine (float duration)
	{
		Material material = GetComponent<Renderer>().material;
		material.color = Color.red;
		yield return new WaitForSeconds(duration);
		material.color = defaultColor;
	}
}
