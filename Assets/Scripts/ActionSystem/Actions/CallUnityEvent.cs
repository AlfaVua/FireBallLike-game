using UnityEngine;
using UnityEngine.Events;

namespace ActionSystem.Actions
{
    public class CallUnityEvent : ActionBase
    {
        [SerializeField] private UnityEvent action;
        public override void Execute()
        {
            action.Invoke();
        }
    }
}