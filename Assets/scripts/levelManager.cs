using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour {

	[System.Serializable]
	public class Level
	{
		public string levelText;
		public bool unlocked;

	}


	public GameObject button;
	public Transform spacer;
	public List<Level> levelList;


	// Use this for initialization
	void Start () {
		FillList ();
		Character.isAlive = true;
	}

	void FillList()
	{
		int n = 0;
		foreach(var level in levelList)
		{
			n++;
			GameObject newButton = Instantiate(button) as GameObject;
			levelButton btn = newButton.GetComponent<levelButton>();
			btn.levelText.text = level.levelText;
			btn.levelNum.text = n.ToString ();

			btn.unlocked = level.unlocked;
			btn.GetComponent<UnityEngine.UI.Button> ().interactable = level.unlocked;

			btn.GetComponent<UnityEngine.UI.Button> ().onClick.AddListener(() => btn.loadLevels()); 

			newButton.transform.SetParent (spacer, false);
		}
	}

	/*void SaveAll()
	{
		GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
		foreach (GameObject butt in allButtons) {
			levelButton btn1 = butt.GetComponent<levelButton> ();

		}
	}*/

	// Update is called once per frame
	void Update () {
	
	}
}
