using UnityEngine;
using System.Collections;

public class FruitScript : MonoBehaviour
{

	public static FruitScript instance;
	//public int score;
	public bool gameOver;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	public GameObject cut1;
	public GameObject cut2;

	// Use this for initialization
	void Start ()
	{
		//score = 0;
		//PlayerPrefs.SetInt ("Score", 0);
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Line" && !gameOver) {
			IncrementScore ();

			GameObject c1 = Instantiate (cut1, transform.position, Quaternion.identity) as GameObject;
			GameObject c2 = Instantiate (cut2, new Vector3 (transform.position.x - 2f, transform.position.y, 0), Quaternion.identity) as GameObject;

			c1.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (2f, 2f), ForceMode2D.Impulse);
			c1.GetComponent<Rigidbody2D> ().AddTorque (Random.Range (-2f, 2f), ForceMode2D.Impulse);

			c2.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-2f, 2f), ForceMode2D.Impulse);
			c2.GetComponent<Rigidbody2D> ().AddTorque (Random.Range (-2f, 2f), ForceMode2D.Impulse);
			Destroy (gameObject);
		}
	}

	public void IncrementScore ()
	{
		UiManager.instance.score++;
	}

	public void StopScore ()
	{
		PlayerPrefs.SetInt ("Score", UiManager.instance.score);
		if (PlayerPrefs.HasKey ("HighScore")) {
			if (UiManager.instance.score > PlayerPrefs.GetInt ("HighScore")) {
				PlayerPrefs.SetInt ("HighScore", UiManager.instance.score);
			}
		} else {
			PlayerPrefs.SetInt ("HighScore", UiManager.instance.score);
		}
	}
}
