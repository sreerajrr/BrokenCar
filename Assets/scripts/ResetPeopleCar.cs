using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPeopleCar : MonoBehaviour {
	


	// Use this for initialization
	void Start () {
	//	peoples = 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "EnemyCar"||other.gameObject.tag == "sideobs")
		{ 
			poepleCarMovement peoples=other.gameObject.GetComponent<poepleCarMovement> ();
			peoples.transormtotop ();
				}


	}
		
	
}
