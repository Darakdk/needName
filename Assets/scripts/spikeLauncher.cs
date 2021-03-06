﻿using UnityEngine;
using System.Collections;

public class spikeLauncher : MonoBehaviour {

    public float offset;
    public float countdown;
	public GameObject projectile;
	private float privCountdown = 0;
	private bool cannonActivated = true;
	public GameObject cannonActive;
	public GameObject cannonInactive;

	void FixedUpdate () {
        if (offset > 0)
        {
            offset = offset - Time.deltaTime;
        }
        if (offset <= 0) {
            privCountdown = privCountdown + Time.deltaTime;
            if (privCountdown >= countdown && cannonActivated)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                privCountdown = 0;
            }
        }
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("playerBullet"))
		{
			cannonActive.SetActive (false);
			cannonInactive.SetActive (true);
			cannonActivated = false;
		}
	}
}
