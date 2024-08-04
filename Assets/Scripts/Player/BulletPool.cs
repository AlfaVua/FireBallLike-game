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
        bullet.gameObject.SetActive(false);
        bullet.transform.position = Vector3.zero;
        bullet.transform.SetParent(poolContainer);
    }
}