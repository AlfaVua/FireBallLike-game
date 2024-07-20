using UnityEngine;

public class OnCollideExecutor : BaseExecutor
{
    [SerializeField] private LayerMask collideWith;
    private void OnCollisionEnter(Collision other)
    {
        if (collideWith.IsInLayer(other.gameObject.layer)) Execute();
    }
}
