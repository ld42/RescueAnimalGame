using UnityEngine;

public class EventConsumer : MonoBehaviour
{
    public GameObject EventDisplayerObject;

    // Update is called once per frame
    void Update()
    {
        GameEvent newEvent = EventManager.instance.GetEvent();
        if (newEvent != null)
        {
            if (newEvent is DisplayableGameEvent)
            {
                TimeManager.instance.PauseGame();
                DisplayableGameEvent gameEvent = newEvent as DisplayableGameEvent;
                EventDisplayerObject.SetActive(true);
                EventDisplayer eventDisplayer = EventDisplayerObject.GetComponent<EventDisplayer>();
                eventDisplayer.SetTitle(gameEvent.Name);
                eventDisplayer.SetMessage(gameEvent.Message);
            }
            if (newEvent.EventAction != null)
            {
                newEvent.ApplyAction();
            }

        }

    }
}
