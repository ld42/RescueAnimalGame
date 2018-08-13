using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinQtyScript : MonoBehaviour {

    public static int coinQuantity = 0;
    Text quantity;
	// Use this for initialization
	void Start () {
        quantity = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        quantity.text = coinQuantity.ToString();
	}
}
