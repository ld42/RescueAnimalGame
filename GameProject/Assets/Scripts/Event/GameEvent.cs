using System;

[Serializable]
public class GameEvent
{
    //public EventType Type;

    public Action EventAction;

    public void ApplyAction()
    {
        EventAction.Invoke();
    }
}

public class DisplayableGameEvent : GameEvent
{
    public string Name;
    public string Message;
}


//[Flags]
//public enum EventType
//{
//    MoreAnimals = 1,
//    LessAnimals = 2,
//    MoreMoney = 4,
//    LessMoney = 8,
//    MoreFood = 16,
//    LessFood = 32
//}
