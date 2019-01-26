using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
		float currentX = this.transform.position.x;
		if(Input.GetKey(KeyCode.Space)) CountSheep(currentX);
	}

	void CountSheep(float currentX){
		GameObject[] sheeps = GameObject.FindGameObjectsWithTag("Sheep");
		foreach (var sheep in sheeps){
			Vector2 positionRange = sheep.GetComponent<Sheep>().getPostionRange();
			if (currentX < positionRange.y & currentX > positionRange.x)
				Destroy(sheep);
			//Debug.Log(positionRange);
		}
	}
}
