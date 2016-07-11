using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool gameActive;
	public GameObject gameOverRender;
	public Text[] shotsTexts;
	public int shots;

	Character player;

	public void Awake ()
	{
		gameActive = true;
		player = GameObject.FindWithTag("Player").GetComponent<Character>();
	}

	void Update ()
	{
		CheckForGameOver();
	}

	public void UpdateShots (int value)
	{
		shots += value;
		print(shots);

		for (int i = 0; i < shotsTexts.Length; i++)
		{
			shotsTexts[i].text = shots.ToString();
		}
	}

	public void CheckForGameOver ()
	{
		if (player == null)
		{
			GameOver();
		}
	}

	public void GameOver ()
	{
		gameActive = false;
		RenderGameOver(true);
	}

	public void Restart ()
	{
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

	void RenderGameOver (bool value)
	{
		gameOverRender.SetActive(value);
	}
}
