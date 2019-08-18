using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class googleplaymanager : MonoBehaviour {
//	bool isconnected;
	public static googleplaymanager Instance { get; private set; }

	void Awake () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}


//	public Text con;
	// Use this for initialization
	void Start () {
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
		GooglePlayGames.PlayGamesPlatform.InitializeInstance (config);
		GooglePlayGames.PlayGamesPlatform.Activate ();
		GooglePlayGames.PlayGamesPlatform.DebugLogEnabled = true;
		signIn ();
		//Debug.Log ("sgfsdfsdf");
	}
	void signIn(){
		if (!Social.localUser.authenticated) {
			Social.localUser.Authenticate (success => {
				//isconnected = success;
			});
		}
	}

	#region
	public static void unlockAcheivements(string id){
		Social.ReportProgress (id, 100, success => {
		});
	}
	#endregion

	public static void IncrementalAchievements(string id ,int stepsToIncrement){
		PlayGamesPlatform.Instance.IncrementAchievement (id, stepsToIncrement, success => {
		});
	} 

	#region showl
	public static void showAchievemntUI(){
	//	if (Social.localUser.authenticated) {
		((PlayGamesPlatform)Social.Active).ShowAchievementsUI ();
			//con.text="hihihihihi";
			//con.text = "Conected";

	//	} else {
//			con.text = "Not Conected";
	//	}
	}
	#endregion /showl
	public static void AddToLeaderBoard(string leaderBoardId,long score){
		Social.ReportScore (score, leaderBoardId, success => {
		});

	}
	public static void showLeaderBoardUI(){
		Social.ShowLeaderboardUI ();
	//	con.text="huhuhuhuhuhuhuh";
	}

	// Update is called once per frame
	void Update () {
	//	con.text=""+PlayerPrefs.GetInt("myCar");
	}
}
