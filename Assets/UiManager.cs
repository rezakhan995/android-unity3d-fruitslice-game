using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	public static UiManager instance;
	public int score;
	public Text scoreText; 
	public Text highScoreText; 
	public GameObject gameOverPanel;

	void Awake(){
		if(instance == null){
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt ("Score", 0);
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString ();
	}

	public void GameOver(){
		highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt ("HighScore").ToString ();
		gameOverPanel.SetActive (true);
	} 

	public void Replay(){
		SceneManager.LoadScene ("level1");
	}

	public void Menu(){
		SceneManager.LoadScene ("menu");
	}
}
