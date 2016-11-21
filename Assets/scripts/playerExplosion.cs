using UnityEngine;
using System.Collections;

public class playerExplosion : MonoBehaviour {

	public AudioSource audioEmitter;
	public AudioClip explosion;

	// Use this for initialization
	void Start () {
		audioEmitter.PlayOneShot (explosion);
	}
}
