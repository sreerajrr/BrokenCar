using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menuManager : MonoBehaviour {
	public GameObject startCar;
//	public Button nextButton, PreviousButton;
//	public GameObject myCar;
	public Sprite[] audioss; 
	public Button audi;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		Instantiate (startCar, new Vector3 (0, -15, 49), Quaternion.identity);
		audi.image.sprite = audioss [0];
	}

	void Update () {

		}

	public void audiostate(){
		if (PlayerPrefs.GetInt ("Audio_State") == 1) {
			PlayerPrefs.SetInt ("Audio_State", 0);
			audi.image.sprite = audioss [PlayerPrefs.GetInt ("Audio_State")];
			AudioListener.volume = 0.5f;
		} else {
			PlayerPrefs.SetInt ("Audio_State", 1);
			audi.image.sprite = audioss [PlayerPrefs.GetInt ("Audio_State")];
			AudioListener.volume = 0f;
		}

	}

	public void loadNormal(){
		CarMovement.setmode (0f);
		SceneManager.LoadScene("Normal");

	}

	public void loadproffesional(){
		CarMovement.setmode(1f);
		SceneManager.LoadScene("Normal");
	}


}
