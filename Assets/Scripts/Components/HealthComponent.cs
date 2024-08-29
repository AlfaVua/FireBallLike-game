using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public readonly UnityEvent<int> OnHealthChanged = new UnityEvent<int>();
    private int _health;

    public int Health => _health;

    public void Init(int health)
    {
        if (_health == health) return;
        _health = health;
        OnHealthChanged.Invoke(health);
    }

    public void ReduceHealth()
    {
        OnHealthChanged.Invoke(--_health);
    }
}