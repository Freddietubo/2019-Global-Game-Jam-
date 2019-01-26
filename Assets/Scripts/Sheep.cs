using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {
	private int sheepType;

	// Use this for initialization
	void Start () {
		//Test for ramdom int generator
		sheepType = Random.Range(0, 4);
		//Debug.Log(sheepType);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getSheepType() { return sheepType; }
}
