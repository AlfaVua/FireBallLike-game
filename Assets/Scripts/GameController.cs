using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private LevelParameters selectedLevel;
    [SerializeField] private PlayerController player;
    [SerializeField] private LevelGenerator generator;

    private void Awake()
    {
        GameControls.Init();
        generator.Init(selectedLevel);
        player.Init(selectedLevel);
    }

    private void OnBulletUsed(int bulletsLeft)
    {
        if (selectedLevel.BulletsAmount == 0) return;
        if (bulletsLeft == 0)
        {
            // todo Game Over condition
        }
    }

    private void OnEnable()
    {
        player.onBulletUsed.AddListener(OnBulletUsed);
    }

    private void OnDisable()
    {
        player.onBulletUsed.RemoveListener(OnBulletUsed);
    }
}
