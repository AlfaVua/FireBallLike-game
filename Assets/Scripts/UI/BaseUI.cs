using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Show()
    {
        animator.Play("Show");
    } 

    public void Hide()
    {
        animator.Play("Hide");
    }
}