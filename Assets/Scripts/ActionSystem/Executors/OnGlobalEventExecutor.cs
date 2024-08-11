using UnityEngine;

public class OnGlobalEventExecutor : BaseExecutor
{
    [SerializeField] private EventName eventName;
    private void OnEnable()
    {
        GlobalEvents.Subscribe(eventName, Execute);
    }

    private void OnDisable()
    {
        GlobalEvents.Unsubscribe(eventName, Execute);
    }
}