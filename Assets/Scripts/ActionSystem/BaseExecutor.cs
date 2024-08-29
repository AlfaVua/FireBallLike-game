using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseExecutor : MonoBehaviour
{
    [SerializeField] private List<ActionBase> actions;
    [SerializeField] private bool executeNextFrame;

    public void Execute()
    {
        if (executeNextFrame) StartCoroutine(nameof(DelayedExecute));
        else ExecuteAll();
    }

    private IEnumerator DelayedExecute()
    {
        yield return new WaitForEndOfFrame();
        ExecuteAll();
    }

    private void ExecuteAll()
    {
        actions.ForEach(a => a.Execute());
    }
}
