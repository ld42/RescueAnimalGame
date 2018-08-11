using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalQtyScript : MonoBehaviour {

    public static int animalMaxQty = 20;
    public static int animalQty = 0;
    Text quantity;

	// Use this for initialization
	void Start () {
        quantity = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        quantity.text = animalQty + " / " + animalMaxQty;
	}
}
