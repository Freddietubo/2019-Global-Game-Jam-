using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {
	private int sheepType;

	// Use this for initialization
	void Start () {
		//Test for ramdom int generator
		int testRamdomInt = Random.Range(0, 4);
		Debug.Log(testRamdomInt);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
