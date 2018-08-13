using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    private Queue<GameEvent> events;

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

    private void Start()
    {
        events = new Queue<GameEvent>();

        StartCoroutine(RandomEventAwaiter());
    }

    public GameEvent GetEvent()
    {
        if (events.Count > 0)
            return events.Dequeue();
        else return null;
    }

    private IEnumerator RandomEventAwaiter()
    {
        while (true)
        {
            yield return new WaitForGameTimeSeconds(1200);
            events.Enqueue(new DisplayableGameEvent
            {
                Name = "Hello my friend",
                Message = "Someone has left a basket with 6 puppies inside at the front door, has rung the bell and left.\nYou'll have to take care of the puppies.",
                EventAction = () => InventoryManager.instance.CurrentAnimalQuantity += 6
            });
            yield return new WaitForGameTimeSeconds(2450);
            events.Enqueue(new DisplayableGameEvent
            {
                Name = "Hello again",
                Message = "It seems that some kind stranger has donated 500 to your account.",
                EventAction = () => InventoryManager.instance.CurrentCoinQuantity += 500
            });
            yield return new WaitForGameTimeSeconds(6000);
            events.Enqueue(new GameEvent
            {
                EventAction = () => InventoryManager.instance.CurrentCoinQuantity -= 200
            });
        }
    }
}
