using UnityEngine;
using System.Collections;

public class randomSoundEffect : MonoBehaviour {

	public AudioSource audioEmitter;
	public AudioClip effect1;
	public AudioClip effect2;
	public AudioClip effect3;
	public AudioClip effect4;
	public int ran;

	// Use this for initialization
	void Start () 
	{
		ran = Random.Range (1, 5);
		if (ran == 1)
		{
			audioEmitter.PlayOneShot (effect1);
		}
		else if (ran == 2)
		{
			audioEmitter.PlayOneShot (effect2);
		}
		else if (ran == 3)
		{
			audioEmitter.PlayOneShot (effect3);
		}
		else if (ran == 4)
		{
			audioEmitter.PlayOneShot (effect4);
		}
	}
}