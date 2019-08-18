using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerScrpt : MonoBehaviour {
	public static managerScrpt Instance { get; private set; }
	// Use this for initialization
	public Text cc;
	void Awake () {
//		if (Instance == null) {
//			Instance = this;
//			DontDestroyOnLoad (gameObject);
//		} else {
//			Destroy (gameObject);
//		}
	}



	public void showAche(){
		if (Social.localUser.authenticated) {
			googleplaymanager.showAchievemntUI ();
			//cc.text="hihihih";
		}


	}
	public void showLeaderboard(){
		//cc.text="huhuhuhu";
		if (Social.localUser.authenticated) {
			googleplaymanager.showLeaderBoardUI ();
		//	
		}
		}
//	public void unl(){
//		if (Social.localUser.authenticated) {
//			googleplaymanager.unlockAcheivements(allresources.achievement_racer);
//		}
//	}



	public void unloackAchievemnts(string id){
		if (Social.localUser.authenticated) {
			googleplaymanager.unlockAcheivements(id);
		}
	}
	public void addtoLeaderboardEasy(long score){
		if (Social.localUser.authenticated) {
			googleplaymanager.AddToLeaderBoard (allresources.leaderboard_easy, score);
		}
	}

	public void addtoLeaderboardAdvanced(long score){
		if (Social.localUser.authenticated) {
			googleplaymanager.AddToLeaderBoard (allresources.leaderboard_advanced,score);
		}
	}
	public void incrementacheivement(string id){
		if (Social.localUser.authenticated) {
			googleplaymanager.IncrementalAchievements (id, 1);
		}
	}
}
