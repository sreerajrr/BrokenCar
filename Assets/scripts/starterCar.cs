using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starterCar : MonoBehaviour {
	public float forces;
	public Sprite[] car;
	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		GetComponent<SpriteRenderer>().sprite = car[PlayerPrefs.GetInt("myCar")];
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, forces),ForceMode2D.Impulse);
		Destroy (gameObject, 8);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
