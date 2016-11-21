using UnityEngine;
using System.Collections;

public class ChangeCameraOffset : MonoBehaviour {

	public float newLeft;
	public float newTop;
    public float newDepth;
	public Camera camera;
	public bool once;
	// Use this for initialization
	void Start () {
		camera.GetComponent<Camera> ();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			camera.GetComponent<cameraScript> ().leftOffset = newLeft;
			camera.GetComponent<cameraScript> ().topOffset = newTop;
            camera.GetComponent<cameraScript>().depthOffset = newDepth;

            if (once)
				Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
