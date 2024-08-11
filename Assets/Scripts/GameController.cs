using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private LevelParameters selectedLevel;
    [SerializeField] private PlayerController player;
    [SerializeField] private LevelGenerator generator;
    [SerializeField] private UIController uiController;
    [SerializeField] private AudioSource globalAudioSource;

    private int activeBullets = 0;
    private float levelStartTime;

    private void Awake()
    {
        GameControls.Init();
        GlobalAudioPlayer.SetSource(globalAudioSource);
        uiController.Init();
        globalAudioSource = null;
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

    private void OnBulletShot(int bulletsLeft)
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
        activeBullets--;
        if (player.CantShoot && activeBullets == 0) EndLevel();
    }

    private void OnEnable()
    {
        player.onBulletShot.AddListener(OnBulletShot);
        GlobalEvents.Subscribe(EventName.BulletDestroyed, OnBulletDestroyed);
        GlobalEvents.Subscribe(EventName.RestartLevel, RestartSelectedLevel);
    }

    private void OnDisable()
    {
        player.onBulletShot.RemoveListener(OnBulletShot);
        GlobalEvents.Unsubscribe(EventName.BulletDestroyed, OnBulletDestroyed);
        GlobalEvents.Unsubscribe(EventName.RestartLevel, RestartSelectedLevel);
    }
}
