    using UnityEngine;

    public class ReduceHealthAction : ActionBase
    {
        [SerializeField] private HealthComponent target;

        public override void Execute()
        {
            target.ReduceHealth();
        }
    }