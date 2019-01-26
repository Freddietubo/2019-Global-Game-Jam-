using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	// Use this for initialization
	private bool isLoaded;
	void Start () {
		//numbers represents the keyboard keys
		Debug.Log((int)KeyCode.Q);
		Debug.Log((int)KeyCode.W);
		Debug.Log((int)KeyCode.E);
		Debug.Log((int)KeyCode.R);
		

		isLoaded = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("1"))
			Debug.Log("IT IS 1");
		if (Input.GetKey("2"))
			Debug.Log("IT IS 2");
		if (Input.GetKey("3"))
			Debug.Log("IT IS 3");
		if (Input.GetKey("4"))
			Debug.Log("IT IS 4");

		//Find the game object
		GameObject[] sheeps = GameObject.FindGameObjectsWithTag("Sheep");
		
		if( isLoaded == false){
			foreach (GameObject sheep in sheeps){
				Debug.Log("Yep");				
			}
		}

		isLoaded = true;
	}
}
