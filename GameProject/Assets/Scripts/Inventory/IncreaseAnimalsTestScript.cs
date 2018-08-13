using UnityEngine;

public class IncreaseAnimalsTestScript : MonoBehaviour
{

    public void IncreaseAnimalQty()
    {
        InventoryManager.instance.CurrentAnimalQuantity += 1;
    }
}
