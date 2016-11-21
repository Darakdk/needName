using UnityEngine;
using System.Collections;

public class enemyExplosion : MonoBehaviour {

    public ParticleSystem effect;
	// Use this for initialization
	void Start () {
        effect.Play();
	}
}
