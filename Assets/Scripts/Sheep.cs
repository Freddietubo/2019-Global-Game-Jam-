using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {
	private int sheepType;
	private Vector2 xPositionRange;

	// Use this for initialization
	void Start () {
		//initiate position range
		float xPosition = this.transform.position.x;
		float xScale = this.transform.localScale.x;
		xPositionRange = new Vector2(xPosition - xScale, xPosition + xScale);

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public Vector2 getPostionRange() { return xPositionRange; }
}
