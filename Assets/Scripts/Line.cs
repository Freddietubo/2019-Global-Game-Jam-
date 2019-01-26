using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
	public float speed;
	private Vector3 destination;
	private Spawner spawner;

	//
	private float currentX;

	// Use this for initialization
	void Start () {
		//initialization
		speed = 3.0f;
		spawner = Spawner.getInstance();
		currentX = spawner.getCurrentX();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);

		//smoothing the movement
		//transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
		

		//deal with the keyboard control
		float linePositionX = this.transform.position.x;
		float sheepPositionX = currentX;
		if(Input.GetKeyUp(KeyCode.Space)) {
			bool isHit = CountSheep(linePositionX, sheepPositionX);
			if(isHit & spawner.isElement()) currentX = spawner.getCurrentX(); 
		}

		if( (linePositionX - sheepPositionX > 0.5f) & spawner.isElement()) {
			spawner.deleteElement();
			Debug.Log("Auto delete");
			if (spawner.isElement()) currentX = spawner.getCurrentX();
		}
	}

	bool CountSheep(float linePositionX, float sheepPositionX){
		if (Mathf.Abs(linePositionX - sheepPositionX) < 0.1f){
			spawner.deleteElement();
			Debug.Log("Perfect");
			return true;
		}

		if (Mathf.Abs(linePositionX - sheepPositionX) < 0.2f){
			spawner.deleteElement();
			Debug.Log("Good");
			return true;
		}

		if (Mathf.Abs(linePositionX - sheepPositionX) < 0.5f){
			spawner.deleteElement();
			Debug.Log("Miss");
			return true;
		}

		return false;
	}
}
