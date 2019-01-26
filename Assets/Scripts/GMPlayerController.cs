using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMPlayerController : MonoBehaviour {

    public GameObject player;

    public float moveSpeed;

    private Rigidbody2D rb2d;

	void Start () {
        rb2d = this.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position -= new Vector3(moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += new Vector3(moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += new Vector3(0, moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position -= new Vector3(0, moveSpeed, 0);
        }
    }
}
