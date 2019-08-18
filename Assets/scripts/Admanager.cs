using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Ad
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Admanager : MonoBehaviour {
	//public Text cc;
	public static bool adfinished;
	// Use this for initialization
	void Start () {
		Advertisement.Initialize ("1559287");
		adfinished = true;
	}

	//void Update(){
	//}

	// Update is called once per frame
	public void showadvers ()
	{
		if (Advertisement.IsReady () && CarMovement.gameOver) {
			adfinished = false;
			Advertisement.Show ("video", new ShowOptions (){ resultCallback = HandleadResult });
		} else
			adfinished = true;


	}



	public void HandleadResult(ShowResult result){
		switch (result) {
		case ShowResult.Finished:
			adfinished = true;
			break;
		case ShowResult.Skipped:
			adfinished = true;
			break;
		case ShowResult.Failed:
			adfinished = true;
			break;
		}
	}
}
