using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownMenu : MonoBehaviour {

    public Animator anim;
    private bool showMenu;

	// Use this for initialization
	void Start () {
        showMenu = false;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	public void DropDown () {
        if (showMenu == true)
        {
            anim.SetBool("showMenu", false);
            showMenu = false;
        }
        else
        {
            anim.SetBool("showMenu", true);
            showMenu = true;
        }
            
    }
}
