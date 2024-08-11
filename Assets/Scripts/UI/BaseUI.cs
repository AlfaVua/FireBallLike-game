using System.Collections;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Show()
    {
        gameObject.SetActive(true);
        animator.Play("Show");
    }

    public void Hide()
    {
        StartCoroutine(nameof(SetActiveRoutine));
        animator.Play("Hide");
    }

    private IEnumerator SetActiveRoutine()
    {
        yield return HideAnimationTime;
        gameObject.SetActive(false);
        
    }

    protected virtual YieldInstruction HideAnimationTime => new WaitForSeconds(.01f);
}