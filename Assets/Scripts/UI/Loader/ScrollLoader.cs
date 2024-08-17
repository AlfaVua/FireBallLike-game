using UnityEngine;

public abstract class ScrollLoader<T> : MonoBehaviour where T : DrawableItem
{
    [SerializeField] protected T itemPrefab;
    [SerializeField] private Transform itemContainer;

    protected void AddItem(T item)
    {
        item.transform.SetParent(itemContainer);
        item.transform.localScale = Vector3.one;
        item.Draw();
    }

    protected void RemoveAllItems()
    {
        foreach (Transform item in itemContainer.transform)
        {
            Destroy(item.gameObject);
        }
    }
}
