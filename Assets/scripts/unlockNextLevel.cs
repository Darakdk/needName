using UnityEngine;
using System.Collections;

public class unlockNextLevel : MonoBehaviour {

    public string nextLevel;

	void OnCollisionEnter (Collision col) {
        if (col.gameObject.layer == 8 || col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
        }
    }
}
