using UnityEngine;
using System.Collections;

public class checkPointSyst : MonoBehaviour {

    public int checkPointNum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider col) //Muerte al colisionar con un enemigo
    {
        if ( col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Character.myChekPoint = checkPointNum;
            Character.position = transform.position;
            gameObject.SetActive(false);
        }
    }


}
