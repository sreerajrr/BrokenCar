using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
	public GameObject taptoButton;
	public GameObject movebutton;
	public static bool isPaused;
	public bool gameOverdelays =false;

	//GameOver
	bool restartnow;
	bool mainmenunow;
	public float gameOverdelay;
	public GameObject restartB;
	public GameObject MainMenuB;
	public GameObject ExitB;
	public Image broken;
	public GameObject pausebutton;
	public GameObject continueGame;

	// Use this for initialization

	void Start () {

		CarMovement.gameOver = false;
		restartnow = false;
		mainmenunow = false;
	}
	
	// Update is called once per frame

	void Update () {
		if (Admanager.adfinished && restartnow) {
			
			Admanager.adfinished = false;
			restartnow = false;
			mainmenunow = false;
			SceneManager.LoadScene("Normal");
		}
		if (Admanager.adfinished && mainmenunow) {
			Admanager.adfinished = false;
			restartnow = false;
			mainmenunow = false;
			SceneManager.LoadScene ("MainScreen");
		
		}
		//gameOver
		Debug.Log("in manager Script"+CarMovement.gameOver);
		if (CarMovement.gameOver) {
			
			Color c = broken.color;
			c.a = 0.7f;
			broken.color = c;
			if (gameOverdelays)
				gameOverdelay = Time.time;
			gameOverdelays = false;

			if (gameOverdelay + 0.5f < Time.time) {
				
				//	gameOverMenu.SetActive (true);

				Manager.isPaused = true;
				c.a = 0.2f;
				broken.color = c;
				restartB.SetActive (true);
				MainMenuB.SetActive (true);
				ExitB.SetActive (true);

				//Manager m= GetComponent<Manager>().pause();
			
			}
		} else {
			Color c = broken.color;
			c.a = 0f;
			broken.color = c;
		}


		pauses ();
		//Debug.Log (isPaused);
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (!isPaused) {
				// if game is not yet paused, ESC will pause it
			//	isPaused = true;

				pauses();
			//	Debug.Log ("sadcvasdcfv");

				Pausepressed ();


			} else { // if game is paused and ESC is pressed, it's the second press. QUIT
				SceneManager.LoadScene ("MainScreen");
			}
		}

	}

	void OnApplicationPause(bool pauseStatus){
		
		if (!pauseStatus) {
			isPaused = pauseStatus;
			Pausepressed ();
		}
	}

	public void Pausepressed(){
		isPaused = !isPaused;
		if (isPaused) {
			restartB.SetActive (true);
			MainMenuB.SetActive (true);
			ExitB.SetActive (true);
			continueGame.SetActive (true);
		}
		else {
			restartB.SetActive (false);
			MainMenuB.SetActive (false);
			ExitB.SetActive (false);
			continueGame.SetActive (false);
		}

	}


	public void taptoplay(){
		Destroy (taptoButton);
		movebutton.SetActive (true);
		pausebutton.SetActive (true);
		isPaused = false;
	}
	public void pause(){
		isPaused = !isPaused;
		Debug.Log ("Pauesed" + isPaused);
	}
	void pauses(){

		//if (Time.timeScale != 0&& isPaused) {

		if(isPaused){

			Time.timeScale = 0;
			movebutton.SetActive (false);
			isPaused = true;

		} 

		//else if (Time.timeScale == 0&&!isPaused) {

		else{
			Time.timeScale = 1;
			isPaused = false;
			movebutton.SetActive (true);

		}
	}

	public void restart(){
		restartnow = true;
	//	SceneManager.LoadScene("Normal");

	}
	public void Mainmenu(){
		mainmenunow = true;
	//	SceneManager.LoadScene ("MainScreen");
	}
	public void exit(){
		Application.Quit();
	}

}
