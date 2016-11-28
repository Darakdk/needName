using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreUpdate : MonoBehaviour {
    public Text scoreText;
	
	void FixedUpdate () {
        scoreText.text = "Score: " + sceneController.overallScore;
	}
}