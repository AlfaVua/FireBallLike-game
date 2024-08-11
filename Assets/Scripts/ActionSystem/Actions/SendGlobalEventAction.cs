using UnityEngine;

public class SendGlobalEventAction : ActionBase
{
    [SerializeField] private EventName eventName;
    public override void Execute()
    {
        GlobalEvents.Call(eventName);
    }
}
