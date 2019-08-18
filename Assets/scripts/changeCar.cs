using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeCar : MonoBehaviour {
	public Image dispImg;
	public Image lockImg;
	public Button unlockButton;
	public Sprite[] myCar;
	private int index;
	public Text pointsNeeded;
	Color c ;
	Color BC;


	//for testing

	//public Text cc;
	// Use this for initialization
	void Start () {
		//GetComponent<SpriteRenderer> ().sprite = myCar [index];
		//PlayerPrefs.SetInt("myCar", index);
		index = PlayerPrefs.GetInt("myCar");
		dispImg.sprite = myCar [index];
		unlockButton.interactable= false;
		unlockButton.gameObject.SetActive (false);
		pointsNeeded.gameObject.SetActive (false);
		c = lockImg.color;
		BC = unlockButton.image.color;
		c.a = 0f;
		lockImg.color = c;

	}

	public void changeButton (bool next)
	{
		if (next)
			index++;
		else
			index--;
		if (index < 0) {
			index = myCar.Length - 1;
		} else if (index > myCar.Length - 1)
			index = 0;
		dispImg.sprite = myCar [index];
		PlayerPrefs.SetInt ("SelectedCar", index);
		Debug.Log (PlayerPrefs.GetInt ("SelectedCar"));
		switch (index) {
		case 0 :
			if(PlayerPrefs.GetInt("unlock")>=0){
				PlayerPrefs.SetInt ("myCar", index);
				c.a = 0f;
				unlockButton.gameObject.SetActive (false);
				lockImg.color = c;
				pointsNeeded.gameObject.SetActive (false);
			}
			break;
		case 1:
			if (PlayerPrefs.GetInt ("unlock") >= 1) {
				PlayerPrefs.SetInt ("myCar", index);
				c.a = 0f;
				unlockButton.gameObject.SetActive (false);
				lockImg.color = c;
				pointsNeeded.gameObject.SetActive (false);
			}
			else{
				c.a = 0.8f;
				lockImg.color = c;
				pointsNeeded.gameObject.SetActive (true);
				unlockButton.gameObject.SetActive (true);
				pointsNeeded.text = "Needs 10000 points";
				if (PlayerPrefs.GetFloat ("Final_Score") > 10000f) {
					BC.a = 1f;
					unlockButton.image.color = BC;
					unlockButton.interactable = true;
				
				}
				else {
					BC.a = 0.5f;
					unlockButton.image.color = BC;
					unlockButton.interactable = false;
				}
			
			}
			break;
		case 2:
			if (PlayerPrefs.GetInt ("unlock") >= 2) {
				PlayerPrefs.SetInt ("myCar", index);
				c.a = 0f;
				unlockButton.gameObject.SetActive (false);
				lockImg.color = c;
				pointsNeeded.gameObject.SetActive (false);
			}
			else{
				c.a = 0.8f;
				lockImg.color = c;
				unlockButton.gameObject.SetActive (true);
				pointsNeeded.gameObject.SetActive (true);
				pointsNeeded.text = "Needs 30000 points";
				if (PlayerPrefs.GetFloat ("Final_Score") > 30000f) {
					BC.a = 1f;
					unlockButton.image.color = BC;
					unlockButton.interactable= true;
				}
				else {
					BC.a = 0.5f;
					unlockButton.image.color = BC;
					unlockButton.interactable = false;
				}
			}
			break;
		case 3:
			if (PlayerPrefs.GetInt ("unlock") >= 3) {
				PlayerPrefs.SetInt ("myCar", index);
				c.a = 0f;
				pointsNeeded.gameObject.SetActive (false);
				unlockButton.gameObject.SetActive (false);
				lockImg.color = c;
			}
			else{
				c.a = 0.8f;
			//	unlockButton.gameObject.SetActive (false);
				lockImg.color = c;
				pointsNeeded.gameObject.SetActive (true);
				unlockButton.gameObject.SetActive (true);
				pointsNeeded.text = "Needs 80000 points";
				if (PlayerPrefs.GetFloat ("Final_Score") > 80000f) {
					BC.a = 1f;
					unlockButton.image.color = BC;
					unlockButton.interactable= true;
				}
				else {
					BC.a = 0.5f;
					unlockButton.image.color = BC;
					unlockButton.interactable = false;
				}
			}
			break;
		default:
			break;
	
		}}
		public void unlockCar(){
		PlayerPrefs.SetInt ("unlock", PlayerPrefs.GetInt ("SelectedCar"));
		c.a = 0f;
		lockImg.color = c;
		unlockButton.gameObject.SetActive (false);
		pointsNeeded.gameObject.SetActive (false);
		if(PlayerPrefs.GetInt("unlock") >= 1){
			googleplaymanager.unlockAcheivements (allresources.achievement_racer);
//			managerScrpt.Instance.unloackAchievemnts (allresources.achievement_racer);

			Debug.Log ("Unlocked");


		}
			
	}

	
	// Update is called once per frame
	void Update(){
		
		//	cc.text = "" + Social.localUser.authenticated;

	}
}
