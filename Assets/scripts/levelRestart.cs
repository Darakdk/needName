using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelRestart : MonoBehaviour {

	public string currentLevel;
	public string MainMenu;
	public bool pressRestart = false;

	// Update is called once per frame
	void Update () {
		pressRestart = Input.GetKey (KeyCode.R);
		if(pressRestart){
			Character.isAlive = true;
			SceneManager.LoadScene (currentLevel, LoadSceneMode.Single);
		}
		pressRestart = Input.GetKey (KeyCode.M);
		if(pressRestart){
			SceneManager.LoadScene (MainMenu, LoadSceneMode.Single);
		}
	}

	void FixedUpdate () {
		
	}
}
