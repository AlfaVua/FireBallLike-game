    using UnityEngine;

    public class ReduceHealthAction : ActionBase
    {
        [SerializeField] private ChestModel target;

        public override void Execute()
        {
            target.ReduceHealth();
        }
    }