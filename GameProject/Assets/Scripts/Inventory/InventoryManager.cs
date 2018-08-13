using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public int InitNumberOfAnimals = 0;
    public int MaxNumberOfAnimals = 50;
    public int InitNumberOfCoin = 0;
    public int MaxNumberOfCoin = 1000;
    public int InitNumberOfFood = 0;
    public int MaxNumberOfFood = 400;

    [HideInInspector]
    public int CurrentAnimalQuantity = 0;
    [HideInInspector]
    public int CurrentCoinQuantity = 0;
    [HideInInspector]
    public int CurrentFoodQuantity = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
