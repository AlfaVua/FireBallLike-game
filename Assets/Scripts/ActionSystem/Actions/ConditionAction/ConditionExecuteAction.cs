using UnityEngine;

public abstract class ConditionExecuteAction : ActionBase
{
    [SerializeField] private BaseExecutor actions;
    protected abstract bool Condition();

    public override void Execute()
    {
        if (Condition()) actions.Execute();
    }
}