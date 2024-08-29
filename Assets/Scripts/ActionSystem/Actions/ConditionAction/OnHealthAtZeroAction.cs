public class OnHealthAtZeroAction : ConditionExecuteAction
{
    public HealthComponent target;
    protected override bool Condition()
    {
        return target.Health == 0;
    }
}