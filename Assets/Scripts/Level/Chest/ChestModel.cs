using TMPro;
using UnityEngine;

public class ChestModel : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private HealthComponent health;

    public bool IsHealthAtZero => health.Health == 0;
    
    public void Init(ChestProperties props)
    {
        body.detectCollisions = true;
        body.isKinematic = false;
        health.Init(props.Health);
        healthText.gameObject.SetActive(true);
    }

    private void OnHealthChanged(int _health)
    {
        healthText.text = health.Health < 2 ? "" : _health.ToString();
        if (IsHealthAtZero)
        {
            body.isKinematic = true;
            body.detectCollisions = false;
            healthText.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        health.OnHealthChanged.AddListener(OnHealthChanged);
    }

    private void OnDisable()
    {
        health.OnHealthChanged.RemoveListener(OnHealthChanged);
    }
}