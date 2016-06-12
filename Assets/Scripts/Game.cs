using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public GameObject gameOverScreen, gameUI, menuUI;
	public Text scoreText, highscore;
	public AudioClip dead;
	public static bool gameOver = false, playing = false;
	public static int score = 0;
	bool setGameOver = false;

	float gameOverTimer = 0;

	// Use this for initialization
	void Start () {
		playing = false;
		setGameOver = false;
		gameOver = false;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(!playing){

			gameUI.SetActive(false);
			menuUI.SetActive(true);

		}else{

			gameUI.SetActive(true);
			menuUI.SetActive(false);

		}

		if(gameOver){

			if(!setGameOver){
				GetComponent<AudioSource>().PlayOneShot(dead);
				PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);
				if(PlayerPrefs.GetInt("GamesPlayed") % 2 == 0){
					GlobalSettings.ShowAd();
				}
				gameOverScreen.SetActive(true);
				CheckHighScore(score);
				highscore.text = "BEST- " + PlayerPrefs.GetInt("Highscore");
				setGameOver = true;
			}

			gameOverTimer += Time.deltaTime;

			if(Input.GetMouseButtonDown(0)){

				if(gameOverTimer > 0.5f){
					Application.LoadLevel("Game");
				}
			}


		}else{

			gameOverScreen.SetActive(false);

		}

		scoreText.text = score.ToString();
	
	}

	void CheckHighScore (int score){

		if(score > PlayerPrefs.GetInt("Highscore")){

			PlayerPrefs.SetInt("Highscore", score);

		}

	}
}
