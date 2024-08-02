public class GameControls
{
    private static Inputs _inputs;
    private static ushort _inputEvents = 0;

    public static void Init()
    {
        _inputs = new Inputs();
    }

    public static void SubscribeGameEvents(Inputs.IGameActions events)
    {
        _inputs.Game.AddCallbacks(events);
        _inputs.Enable();
        _inputEvents++;
    }

    public static void UnsubscribeGameEvents(Inputs.IGameActions events)
    {
        _inputs.Game.RemoveCallbacks(events);
        if (--_inputEvents == 0) _inputs.Disable();
    }
}
