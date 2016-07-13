using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	Vector3 startMarker;
	float startTime;
	float journeyLength;

  public Vector3 target;
  public float speed = 20f;
	public bool moving;
	public bool diagonal;

	void Awake ()
	{
		startMarker = transform.position;
	}

	void Start ()
	{
		ProcessMove();
	}

  public void ProcessMove ()
	{
    startTime = Time.time;
    startMarker = Round(transform.position);
    journeyLength = Vector3.Distance(startMarker, target);
    StartCoroutine(Move());
  }

  IEnumerator Move ()
	{
		while (transform.position != target)
		{
			moving = true;
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startMarker, target, fracJourney);
			yield return null;
		}
		moving = false;
		target = startMarker;
		ProcessMove();
	}

	Vector3 Round (Vector3 vec)
	{
		return new Vector3(
			Mathf.Round(vec.x/0.5f) * 0.5f,
			Mathf.Round(vec.y/0.5f) * 0.5f,
			Mathf.Round(vec.z/0.5f) * 0.5f
		);
	}
}
