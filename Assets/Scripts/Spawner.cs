using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	private Queue sheepQueue;

	//make the spawner singleton
	static Spawner instance;
	public static Spawner getInstance() { return instance; }

	// Use this for initialization
	void Start () {
		//initialize the instance
		instance = this;
		//Load the prefeb
		GameObject sheepPrefab = (GameObject)Resources.Load("Prefebs/SheepPlaceHolder", typeof(GameObject));
		sheepQueue = new Queue();
		//Random Position and generate the sheeps
		float rangeLeft = -5.0f;
		float rangeRight = -4.0f;
		for (int i = 0; i < 5; i++){
			Vector3 sheepPosition = new Vector3(Random.Range(rangeLeft, rangeRight), 0.0f, 0.0f);
			GameObject sheep = Instantiate(sheepPrefab, sheepPosition, Quaternion.identity);
			sheepQueue.Enqueue(sheep);
			rangeLeft += 2.0f;
			rangeRight += 2.0f;
		}

		//Spawn the line
		GameObject line = (GameObject)Resources.Load("Prefebs/Line", typeof(GameObject));
		Instantiate(line, new Vector3(-8.0f, 0.0f, 0.0f), Quaternion.identity);
	}
	
	public GameObject getSheepQueue() { return (GameObject)sheepQueue.Peek(); }

	public float getCurrentX() { 
		GameObject sheep = (GameObject)sheepQueue.Peek();
		return sheep.transform.position.x;
	}

	public bool deleteElement() {
		if (sheepQueue.Count != 0){
			GameObject sheep = (GameObject)sheepQueue.Dequeue();
			Destroy(sheep);
			return true;
		}

		return false;
	}

	public bool isElement() { return sheepQueue.Count != 0;}
}
