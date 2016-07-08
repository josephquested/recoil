using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool gameActive;

	void Update ()
	{
		if (GameObject.FindWithTag("Player") == null)
		{
			gameActive = false;
		}
	}
}
