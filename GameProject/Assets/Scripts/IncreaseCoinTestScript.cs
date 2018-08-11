using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCoinTestScript : MonoBehaviour {

    public void AddCoin()
    {
        CoinQtyScript.coinQuantity += 1;
    }
}
