using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poepleCarMovement : MonoBehaviour {
	//public float speedcar;
	public static float CarSpeed;
	//public GameObject car;
	float[] positions= {3.8f, 0f,-3.8f};
	float[] positionobs= {-6.7f,6.7f};
	public Sprite[] s;
	public static float i =0;
	public float speedTime;
	float currentTime;
	// Use this for initialization
	void Start () {
		int spritesize = s.Length;
		int Ro = Random.Range (0, spritesize);
		GetComponent<SpriteRenderer> ().sprite = s [Ro];
	///	CarSpeed = 13f;
		currentTime = Time.time;
		speedTime = 3;
	//	CarSpeed = car.GetComponent<CarMovement> ().CarSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log( "Carspeed = " +CarSpeed);
	//	transform.Translate (new Vector3 (0, -1, 0) * CarSpeed * Time.deltaTime);
		if (currentTime + speedTime < Time.time) {
			CarSpeed +=0.125f ;
			//i++;
		//	Debug.Log (CarSpeed);
			if (CarSpeed >= 29) {
			}
			else if (CarSpeed > 15) {
				speedTime = 6;
			}else 

				speedTime += 4f;
			currentTime = Time.time;
		}
		if(tag == "EnemyCar")
		GetComponent<Rigidbody2D>().velocity = new Vector2(0,-CarSpeed);
		else if (tag == "sideobs")
			GetComponent<Rigidbody2D>().velocity = new Vector2(0,-25);
	}

	void OnCollisionEnter2D(Collision2D other){
		//Destroy (gameObject,1f);
	}

	public void changeSprit(){
		int Ro = Random.Range (0, s.Length);
		GetComponent<SpriteRenderer> ().sprite = s [Ro];
	}
	public void transormtotop(){
		if (tag == "EnemyCar") {
			int p = Random.Range (0, 3);
			transform.position = new Vector3 (positions [p], 27.9f, 45f);

			changeSprit ();
		}
		if (tag == "sideobs") {
			int p = Random.Range (0, 2);
			transform.position = new Vector3 (positionobs[p], 27.9f, 45f);

			changeSprit ();
		}
	}

}
