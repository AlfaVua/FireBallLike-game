using UnityEngine;

public class PlayAnimationAction : ActionBase
{
    [SerializeField] private Animator animator;
    [SerializeField] private string animationName;
    public override void Execute()
    {
        animator.Play(animationName);
    }
}