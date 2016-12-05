using UnityEngine;
using System.Collections;

public class ChangeCameraOffset : MonoBehaviour {

	public float newLeft;
	public float newTop;
    public float newDepth;
	public Camera cameratron;
	public bool once;
	// Use this for initialization
	void Start () {
        cameratron.GetComponent<Camera> ();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
            cameratron.GetComponent<cameraScript> ().leftOffset = newLeft;
            cameratron.GetComponent<cameraScript> ().topOffset = newTop;
            cameratron.GetComponent<cameraScript>().depthOffset = newDepth;

            if (once)
				Destroy (gameObject);
		}
	}
}
