using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour {
	public Text Easy;
	public Text Advanced;
	public Text finalScore;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetFloat ("HighScore_Easy", 0f);
		float easyS =PlayerPrefs.GetFloat ("HighScore_Easy");
		float advs = PlayerPrefs.GetFloat ("HighScore_Advanced");
		float FScore = PlayerPrefs.GetFloat ("Final_Score");
		finalScore.text = ": " + FScore;
		Easy.text = ": " + easyS;
		Advanced.text = ": " + advs;
		//Debug.Log ("Working");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
