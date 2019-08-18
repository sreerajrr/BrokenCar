using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour {
	// mode 3



	//public GameObject taptoButtonmode3;

	//car basics
	public float horizontalSpeed;
	public float CarSpeed;

	Rigidbody2D myCarRB;
	public static bool goingRight=true;

	//score Text
	public Text scoreText;
	int Score =0;
	//begintime
	float currentTime;
	float currentTimefor;
	float startPeopleSpeed;
	bool begin = false;

	public static float mode;
	public static bool gameOver = false;

	/*
	public float gameOverdelay;
	public GameObject restartB;
	public GameObject MainMenuB;
	public GameObject ExitB;
	*/
	float easyS;
	float advs;
	// Use this for initialization
	void Start () {
		//Debug.Log (PlayerPrefs.GetFloat ("TimesPlayed"));

		gameOver = false;
		myCarRB = GetComponent<Rigidbody2D> ();

		easyS =PlayerPrefs.GetFloat ("HighScore_Easy");
		advs = PlayerPrefs.GetFloat ("HighScore_Advanced");
		myCarRB.velocity =  new Vector2 (1, 0) * horizontalSpeed;
		currentTime = Time.time;
		currentTimefor = Time.time;
		scoreText.text="Score : 0 ";
		Manager.isPaused = false;
		//peopfun = peopleCar.GetComponent<poepleCarMovement> ();
		poepleCarMovement.CarSpeed = CarSpeed;
	    
		//Debug.Log (gameObject.name);
		startPeopleSpeed= CarSpeed;
	}

	public static void setmode(float m){
		mode = m;
	}
	// Update is called once per frame


	void Update () {
		Debug.Log("in Carmovement Script"+gameOver);
		Debug.Log("in carmovement Script 2"+CarMovement.gameOver);
	//	Debug.Log (poepleCarMovement.CarSpeed);
		if (currentTimefor + 0.1f < Time.time&& !begin) {
			Time.timeScale = 0f;
			begin = true;
		
			Manager.isPaused = true;
		}

		float timeScore =1/ (poepleCarMovement.CarSpeed-3);
		if (currentTime + timeScore < Time.time && !gameOver) {
			Score += (5*((PlayerPrefs.GetInt("myCar")/2)+1));
			scoreText.text = "Score : " + Score ;

			currentTime = Time.time;
			if(Score>4000f && Score <4100f && mode == 0f  ){
				googleplaymanager.unlockAcheivements (allresources.achievement_getting_started);
			}

			if(Score>1200f && Score <1210f && mode == 1f){
				googleplaymanager.unlockAcheivements (allresources.achievement_proffesional);
				//managerScrpt.Instance.unloackAchievemnts (allresources.achievement_proffesional);
			}
			if (PlayerPrefs.GetFloat ("HighScore_Advanced") > 500f && Score > 10000f && Score < 10100f && mode == 0f)
				googleplaymanager.unlockAcheivements (allresources.achievement_improving);
					
		
			if (PlayerPrefs.GetFloat ("HighScore_Easy") > 10000f && Score > 500f && Score < 510f && mode == 1f)
				googleplaymanager.unlockAcheivements (allresources.achievement_improving);
		}
		if (startPeopleSpeed+2 <= poepleCarMovement.CarSpeed) {
			horizontalSpeed += poepleCarMovement.CarSpeed * 0.1f;
			startPeopleSpeed = poepleCarMovement.CarSpeed;

		}
		if(Input.GetMouseButtonDown(0)){

		}
		if (Input.GetAxis ("Horizontal") > 0) {

			MoveRight ();
		
		}
		else if (Input.GetAxis ("Horizontal") < 0) {
	
			MoveLeft ();
		}

		if (goingRight)
			MoveRight ();
		else
			MoveLeft ();

	}
/*	public void carMovementss(){
		if (goingRight)
			MoveLeft ();
		else
			MoveRight ();
	}
*/
	public void MoveLeft(){
		if (!gameOver && (mode == 0f || mode == 1f)) {
			myCarRB.velocity = new Vector2 (-1, 0) * horizontalSpeed;
			goingRight = false;
		} 
	}
	public void MoveRight(){
		if (!gameOver && (mode == 0f || mode == 1f)) {
			myCarRB.velocity = new Vector2 (1, 0) * horizontalSpeed;

			goingRight = true;
		}
	
	}


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "EnemyCar" || (other.gameObject.tag == "Finish" && mode == 1f)) {
			
			Destroy (gameObject, 2f);

			Time.timeScale = 0.3f;
			if (!gameOver) {
				googleplaymanager.IncrementalAchievements (allresources.achievement_dream_player, 1);
				gameOver = true;
			}
			if (mode == 0f) {
				PlayerPrefs.SetFloat ("Final_Score", PlayerPrefs.GetFloat ("Final_Score") + Score);
				if (Score > easyS) {
					googleplaymanager.AddToLeaderBoard(allresources.leaderboard_easy,Score);
					PlayerPrefs.SetFloat ("HighScore_Easy", Score);
				}
			}
			if (mode == 1f) {

				PlayerPrefs.SetFloat ("Final_Score" ,PlayerPrefs.GetFloat ("Final_Score") +(2* Score));
				if (Score > advs) {
					googleplaymanager.AddToLeaderBoard (allresources.leaderboard_advanced, Score);
					PlayerPrefs.SetFloat ("HighScore_Advanced", Score);
				}
			}
			PlayerPrefs.SetFloat ("TimesPlayed" ,PlayerPrefs.GetFloat ("TimesPlayed") +1);
//			if (PlayerPrefs.GetFloat ("TimesPlayed") >500f )
//				googleplaymanager.unlockAcheivements (allresources.achievement_dream_player);

			if (PlayerPrefs.GetFloat ("Final_Score") > 100000f)
				googleplaymanager.unlockAcheivements (allresources.achievement_runner);



			myCarRB.velocity = Vector2.zero;
		
			
		}
	}
}
