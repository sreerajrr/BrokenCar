using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playcar : MonoBehaviour {
	public GameObject[] myCar;
	public GameObject mm;
	// Use this for initialization
	void Start () {
		myCar = new GameObject[transform.childCount];
		for(int i = 0;i<transform.childCount;i++)
		myCar [i] = transform.GetChild (i).gameObject;
		myCar [PlayerPrefs.GetInt("myCar")].SetActive (true);
		//myCar [0].SetActive (true);
	}
	
	public void moveoppo(){
		CarMovement.goingRight = !CarMovement.goingRight;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
