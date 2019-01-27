using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCon : MonoBehaviour {

    
    public Animator animator;
	// Use this for initialization
	void Start () {
        animator.SetBool("isRoommateIn", true);
        animator.SetBool("isRoommateOut", true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
