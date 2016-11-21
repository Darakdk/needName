using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject activator;
    public GameObject activatedObject;
    public float buttonCountdown;
    private float countdown = 0;
    private bool buttonActive = false;
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (buttonActive == true)
        {
            countdown = countdown + Time.deltaTime;
            if (countdown >= buttonCountdown)
            {
                activator.SetActive(true);
                activatedObject.SetActive(true);
                countdown = 0;
                buttonActive = false;
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 9)
        {
            activator.SetActive (false);
            activatedObject.SetActive(false);
            buttonActive = true;
            //Insert effect of button here
        }
    }

}
