using System;
using System.Collections.Generic;

public static class GlobalEvents
{
    private static Dictionary<EventName, List<Action>> events = new Dictionary<EventName, List<Action>>();
    
    public static void Subscribe(EventName eventName, Action @event) {
        if (!events.ContainsKey(eventName))
        {
            events.Add(eventName, new List<Action>());
        }
        events[eventName].Add(@event);
    }

    public static void Unsubscribe(EventName eventName, Action @event)
    {
        events[eventName].Remove(@event);
    }

    public static void Call(EventName eventName)
    {
        events[eventName]?.ForEach(action => action.Invoke());
    }
}

public enum EventName
{
    BulletDestroyed,
    RestartLevel
}