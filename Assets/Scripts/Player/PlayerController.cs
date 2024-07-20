using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, Inputs.IGameActions
{
    [SerializeField] private float shootCooldown = .2f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private BulletPool bulletPool;

    private bool isOnCooldown;

    public void OnShoot(InputAction.CallbackContext context)
    {
        Shoot();
    }

    private void Shoot()
    {
        if (isOnCooldown) return;
        var bullet = CreateOrGetBullet();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = shootingPoint.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.Init(15);
        StartCoroutine(nameof(ShootRoutine));
    }

    private Bullet CreateOrGetBullet()
    {
        var poolBullets = bulletPool.transform.childCount;
        if (poolBullets == 0) return Instantiate(bulletPrefab);
        var bullet = bulletPool.transform.GetChild(0).GetComponent<Bullet>(); 
        bullet.transform.SetParent(null);
        return bullet;
    }

    private IEnumerator ShootRoutine()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(shootCooldown);
        isOnCooldown = false;
    }

    private void OnEnable()
    {
        GameControls.SubscribeGameEvents(this);
    }

    private void OnDisable()
    {
        GameControls.UnsubscribeGameEvents(this);
    }
}
