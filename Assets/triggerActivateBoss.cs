using UnityEngine;
using System.Collections;

public class triggerActivateBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            EnemyBossCuboid.bossActive = true;
        }
    }

}
