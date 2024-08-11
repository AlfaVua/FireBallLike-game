using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private LevelParameters selectedLevel;
    [SerializeField] private PlayerController player;
    [SerializeField] private LevelGenerator generator;
    [SerializeField] private UIController uiController;

    private int activeBullets = 0;
    private float levelStartTime;

    private void Awake()
    {
        GameControls.Init();
        uiController.Init();
    }

    private void RestartSelectedLevel()
    {
        StartLevel(selectedLevel);
    }

    private void StartLevel(LevelParameters level)
    {
        selectedLevel = level;
        uiController.ShowGameUI();
        uiController.GameUI.SetBulletsAmount(selectedLevel.BulletsAmount);
        generator.Init(selectedLevel);
        player.Init(selectedLevel);
        levelStartTime = Time.realtimeSinceStartup;
    }

    private void OnBulletUsed(int bulletsLeft)
    {
        if (selectedLevel.BulletsAmount == 0) return;
        uiController.GameUI.SetBulletsAmount(bulletsLeft);
        activeBullets++;
    }

    private void EndLevel()
    {
        uiController.ShowGameOverUI(
            generator.IsChestOpened ? OverUIState.COMPLETE : OverUIState.LOST, 
            Time.realtimeSinceStartup - levelStartTime
            );
    }

    private void OnBulletDestroyed()
    {
        if (player.CantShoot && --activeBullets == 0) EndLevel();
    }

    private void OnEnable()
    {
        player.onBulletUsed.AddListener(OnBulletUsed);
        GlobalEvents.Subscribe(EventName.BulletDestroyed, OnBulletDestroyed);
        GlobalEvents.Subscribe(EventName.RestartLevel, RestartSelectedLevel);
    }

    private void OnDisable()
    {
        player.onBulletUsed.RemoveListener(OnBulletUsed);
        GlobalEvents.Unsubscribe(EventName.BulletDestroyed, OnBulletDestroyed);
        GlobalEvents.Unsubscribe(EventName.RestartLevel, RestartSelectedLevel);
    }
}
