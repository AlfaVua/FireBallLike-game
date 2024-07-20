using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    public void Init(float speed)
    {
        _speed = speed;
    }

    private void FixedUpdate()
    {
        transform.position += _speed * Time.fixedDeltaTime * Vector3.forward;
    }

    public void MoveToPool() // used at unity event
    {
        BulletPool.MoveBulletToPool(this);
    }
}
