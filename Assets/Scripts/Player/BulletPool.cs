using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static Transform poolContainer;

    private void Awake()
    {
        poolContainer = transform;
    }

    public static void MoveBulletToPool(Bullet bullet)
    {
        bullet.transform.position = Vector3.zero;
        bullet.transform.SetParent(poolContainer);
        bullet.gameObject.SetActive(false);
    }
}