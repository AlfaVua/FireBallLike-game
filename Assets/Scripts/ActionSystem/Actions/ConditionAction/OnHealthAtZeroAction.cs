public class OnHealthAtZeroAction : ConditionExecuteAction
{
    public ChestModel target;
    protected override bool Condition()
    {
        return target.GetHealth() == 0;
    }
}