using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAnimationController : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        //get animal count
	}
	
	public void PressEventButton () {
        //anim.SetTrigger("activateBuff");
        anim.SetBool("activeBuff", true);
	}

    public void EndBuff()
    {
        if (anim.GetBool("activeBuff") != false)
        {
            anim.SetBool("activeBuff", false);
            if (AnimalQtyScript.animalQty > 0)
            {
                //TODO
                //Make animalQty and moneyToEarn a manager var in order to choose qty
                AnimalQtyScript.animalQty -= 1;
            }
            CoinQtyScript.coinQuantity += 10;
        }
    }
}
