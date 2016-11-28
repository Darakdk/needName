using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class levelRestart : MonoBehaviour {

	public string currentLevel;
	public string MainMenu;
	public bool pressRestart = false;
    public GameObject character;
    public GameObject playerRenderer;
    public GameObject cannonRenderer;
    public GameObject playerDeathScreen;
    private static List<Enemy> enemyList = new List<Enemy>();

    // Update is called once per frame
    void Update () {
		pressRestart = Input.GetKey (KeyCode.R);
		if(pressRestart){
			Character.isAlive = true;
            //SceneManager.LoadScene (currentLevel, LoadSceneMode.Single);
            playerRenderer.SetActive(true);
            cannonRenderer.SetActive(true);
            playerDeathScreen.SetActive(false);
            character.SetActive(true);
            character.transform.position = Character.position;
            foreach(Enemy enem in enemyList)
            {
                enem.returnToStart();
            }
		}
		pressRestart = Input.GetKey (KeyCode.M);
		if(pressRestart){
			SceneManager.LoadScene (MainMenu, LoadSceneMode.Single);
		}
	}

    public static void addEnemy(Enemy ene)
    {
        enemyList.Add(ene);
    }
}
