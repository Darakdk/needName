using UnityEngine;
using System.Collections;

public class AutodestructinNseconds : MonoBehaviour {

	public float lifeTime;
	private float countdown;

	// Use this for initialization
	void Start () {
		countdown = lifeTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		countdown = countdown - Time.deltaTime;
		if (countdown <= 0) {
			Destroy (this.gameObject);
		}
	}
}
