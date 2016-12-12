using UnityEngine;
using System.Collections;

public class spikeScript : MonoBehaviour {

    public float countdown;
	public GameObject spikes;
	private float privCountdown = 0;
	private bool spikesActivated = false;

    void FixedUpdate() {
        privCountdown = privCountdown + Time.deltaTime;
        if (privCountdown >= countdown)
        {
            if (spikesActivated == false)
            {
                spikes.SetActive(true);
                spikesActivated = true;
            }
            else
            {
                spikes.SetActive(false);
                spikesActivated = false;
            }
            privCountdown = 0;
        }
    }
}
