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
                Type = EventType.MoreAnimals,
                Name = "Hello my friend",
                Message = "This shit seems to be working... Lorem y tal"
            });
            yield return new WaitForGameTimeSeconds(2450);
            events.Enqueue(new DisplayableGameEvent
            {
                Type = EventType.MoreAnimals,
                Name = "Hello again",
                Message = "This shit seems to be working... Lorem y tal"
            });
            yield return new WaitForGameTimeSeconds(6000);
            events.Enqueue(new DisplayableGameEvent
            {
                Type = EventType.MoreAnimals,
                Name = "Byebye",
                Message = "This shit seems to be working... Lorem y tal"
            });
        }
    }
}
