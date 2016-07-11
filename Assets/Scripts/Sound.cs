using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{
	AudioSource audioSource;

	public AudioClip fireClip;

	void Awake ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void Fire ()
	{
		audioSource.clip = fireClip;
		audioSource.Play();
	}

}
