using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
  Vector3 startMarker;
  Vector3 target;
  float speed = 20f;
  float startTime;
  float journeyLength;

	public bool moving;
	public bool diagonal;

  public void ProcessMove (float recoil)
	{
    if (diagonal) recoil *= 1.5f;
    target = Round(transform.TransformPoint(Vector3.back * recoil));
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
	}

  public bool IsGrounded ()
  {
    float distToGround = GetComponent<Collider>().bounds.extents.y;
    return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
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
