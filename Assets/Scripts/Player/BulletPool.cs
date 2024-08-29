using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Transform activeContainer;
    [SerializeField] private Transform poolContainer;
    private static Transform _poolContainer;
    private static Transform _activeContainer;

    private void Awake()
    {
        _poolContainer = poolContainer;
        _activeContainer = activeContainer;
    }

    public static bool HasBulletsInPool => _poolContainer.childCount != 0;

    public static void Clear()
    {
        foreach (Transform child in _activeContainer)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in _poolContainer)
        {
            Destroy(child.gameObject);
        }
    }

    public static void AddBullet(Bullet bullet)
    {
        bullet.transform.SetParent(_activeContainer);
    }

    public static void MoveBulletToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.position = Vector3.zero;
        bullet.transform.SetParent(_poolContainer);
    }

    public static Bullet GetFirstBulletInPool()
    {
        return _poolContainer.GetChild(0).GetComponent<Bullet>();
    }
}