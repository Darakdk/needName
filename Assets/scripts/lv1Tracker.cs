using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lv1Tracker : MonoBehaviour {

	string levelObjective;
	public Text UIObjective;
	string levelAchieved;
	public Text UIAchieved;
	public GameObject winScreen;
	public GameObject levelGoal;
	private bool gameWon;
	private bool pressRestart = false;
	public string currentLevel;

	// Use this for initialization
	void Start () {
		levelObjective = "Get the Golden Orb!";
		UIObjective.text = levelObjective;
		levelAchieved = "You got the Golden Orb!";
		UIAchieved.text = levelAchieved;
		gameWon = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		pressRestart = Input.GetKey (KeyCode.R);
		if(pressRestart && gameWon){
			SceneManager.LoadScene (currentLevel, LoadSceneMode.Single);
		}
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.layer == LayerMask.NameToLayer("LevelObjective")){
			winScreen.SetActive (true);
			UIObjective.text = "Press R to load next level";
			Character.isAlive = false;
			gameWon = true;
		}
	}
}