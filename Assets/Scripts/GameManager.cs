using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool gameActive;
	public GameObject loseRender;
	public GameObject winRender;
	public Text[] shotsTexts;
	public int shots;

	public void Awake ()
	{
		gameActive = true;
	}

	public void UpdateShots (int value)
	{
		shots += value;
		for (int i = 0; i < shotsTexts.Length; i++)
		{
			shotsTexts[i].text = shots.ToString();
		}
	}

	public void Lose ()
	{
		gameActive = false;
		loseRender.SetActive(true);
	}

	public void Win ()
	{
		gameActive = false;
		winRender.SetActive(true);
	}

	public void LoadNextLevel ()
	{
		int scene = SceneManager.GetActiveScene().buildIndex + 1;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

	public void Restart ()
	{
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}
}
