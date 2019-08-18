using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackMovement : MonoBehaviour {
	public float speed;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		offset = new Vector3 (0, Time.time * speed);
		//offset = new Vector3(0,speed);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
