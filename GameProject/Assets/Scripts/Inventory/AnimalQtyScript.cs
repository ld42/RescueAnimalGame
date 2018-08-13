using UnityEngine;
using UnityEngine.UI;

public class AnimalQtyScript : MonoBehaviour
{

    private int animalMaxQty = 20;
    private int animalQty = 0;

    Text quantity;

    // Use this for initialization
    void Start()
    {
        animalMaxQty = InventoryManager.instance.MaxNumberOfAnimals;
        animalQty = InventoryManager.instance.InitNumberOfAnimals;
        quantity = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        animalQty = InventoryManager.instance.CurrentAnimalQuantity;
        quantity.text = animalQty + " / " + animalMaxQty;
    }
}
