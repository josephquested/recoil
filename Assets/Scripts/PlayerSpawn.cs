using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour
{
	public GameObject playerPrefab;

	void Awake ()
	{
		Instantiate(playerPrefab,
		transform.position - Vector3.down * -20,
		transform.rotation);
	}
}
