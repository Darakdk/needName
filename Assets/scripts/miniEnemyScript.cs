using UnityEngine;
using System.Collections;

public class miniEnemyScript : MonoBehaviour {

    public float lifeTime;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        lifeTime--;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
