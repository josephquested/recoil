using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool gameActive;
	public GameObject gameOverRender;
	public Text[] scoreTexts;
	public int score;

	Character player;

	public void Awake ()
	{
		gameActive = true;
		player = GameObject.FindWithTag("Player").GetComponent<Character>();
		StartCoroutine(ScoreCoroutine());
	}

	void Update ()
	{
		CheckForGameOver();
	}

	IEnumerator ScoreCoroutine ()
	{
		while (gameActive)
		{
			score++;
			for (int i = 0; i < scoreTexts.Length; i++)
			{
				scoreTexts[i].text = score.ToString();
			}
			yield return new WaitForSeconds(1f);
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
