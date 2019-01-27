using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCon : MonoBehaviour {

    static AnimationCon instance;

	public static AnimationCon getInstance(){ return instance; }
    public Animator animator;
	// Use this for initialization
	void Start () {

		instance = this;
       // animator.SetBool("isRoommateIn", true);
       // animator.SetBool("isRoommateOut", true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
