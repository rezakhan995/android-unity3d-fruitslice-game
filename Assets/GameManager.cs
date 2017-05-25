using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;
	bool gameOver;

	void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);

		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start ()
	{
		gameOver = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void GameStart ()
	{
		FruitSpawner.instance.StartSpawning ();
	}

	public void GameOver ()
	{
		FruitSpawner.instance.StopSpawning ();
		FruitScript.instance.StopScore ();
		gameOver = false;
		UiManager.instance.GameOver ();
	}
}
