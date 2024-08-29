using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    public void Init(float speed)
    {
        _speed = speed;
        BulletPool.AddBullet(this);
    }

    private void FixedUpdate()
    {
        transform.position += _speed * Time.fixedDeltaTime * Vector3.forward;
    }

    public void MoveToPool() // used at unity event
    {
        BulletPool.MoveBulletToPool(this);
    }

    private void OnEnable()
    {
        GlobalEvents.Subscribe(EventName.RestartLevel, MoveToPool);
    }

    private void OnDisable()
    {
        GlobalEvents.Unsubscribe(EventName.RestartLevel, MoveToPool);
    }
}
