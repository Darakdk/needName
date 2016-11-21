using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelButton : MonoBehaviour {

	public Text levelText;
	public bool unlocked;
	public Text levelNum;

	public void loadLevels()
	{
		SceneManager.LoadScene (levelText.text, LoadSceneMode.Single);
	}

}
