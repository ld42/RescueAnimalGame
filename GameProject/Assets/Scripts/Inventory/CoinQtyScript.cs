using UnityEngine;
using UnityEngine.UI;

public class CoinQtyScript : MonoBehaviour
{
    Text quantity;
    // Use this for initialization
    void Start()
    {
        quantity = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        quantity.text = InventoryManager.instance.CurrentCoinQuantity.ToString();
    }
}
