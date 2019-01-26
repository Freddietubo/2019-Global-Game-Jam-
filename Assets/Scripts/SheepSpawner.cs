﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Load the prefeb
		GameObject sheep = (GameObject)Resources.Load("Prefebs/SheepPlaceHolder", typeof(GameObject));

		//Random Position and generate the sheeps
		for (int i = 0; i < 10; i++){
			Vector3 sheepPosition = new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(-3.0f, 3.0f), 0.0f);
			Instantiate(sheep, sheepPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
