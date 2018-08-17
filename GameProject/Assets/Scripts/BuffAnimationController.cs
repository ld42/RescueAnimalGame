using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAnimationController : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	public void PressEventButton () {
        //anim.SetTrigger("activateBuff");
        anim.SetBool("activeBuff", true);
	}
}
