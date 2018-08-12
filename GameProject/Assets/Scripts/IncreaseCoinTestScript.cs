using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCoinTestScript : MonoBehaviour {

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Press()
    {
        anim.SetTrigger("press");
    }

    public void AddCoin()
    {
        CoinQtyScript.coinQuantity += 1;
    }
}
