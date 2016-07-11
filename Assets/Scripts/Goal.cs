using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
	GameManager gameManager;

	void Awake ()
	{
		gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.CompareTag("Player"))
		{
			gameManager.Win();
		}
	}
}
