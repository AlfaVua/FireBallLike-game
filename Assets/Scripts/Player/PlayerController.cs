using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, Inputs.IGameActions
{
    [SerializeField] private float shootCooldown = .2f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private BulletPool bulletPool;

    public readonly UnityEvent<int> onBulletShot = new UnityEvent<int>();

    private bool isHolding;
    private bool isOnCooldown;
    private int bullets;
    private bool infiniteBullets;

    public bool CantShoot => !infiniteBullets && bullets == 0;

    public void Init(LevelParameters levelParameters)
    {
        bullets = levelParameters.BulletsAmount;
        infiniteBullets = bullets == 0;
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        Shoot();
        isHolding = context.performed;
    }

    private void Shoot()
    {
        if (isOnCooldown || CantShoot) return;
        var bullet = CreateOrGetBullet();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = shootingPoint.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.Init(15);
        StartCoroutine(nameof(ShootRoutine));
        onBulletShot.Invoke(--bullets);
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
        if (isHolding) Shoot();
    }

    private void OnEnable()
    {
        GameControls.SubscribeGameEvents(this);
    }

    private void OnDisable()
    {
        GameControls.UnsubscribeGameEvents(this);
        isHolding = false;
    }
}
