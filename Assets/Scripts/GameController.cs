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
        uiController.Init(this);
        globalAudioSource = null;
    }

    public void ChangeLevel(LevelParameters newLevel)
    {
        selectedLevel = newLevel;
    }

    private void RestartSelectedLevel()
    {
        StartLevel(selectedLevel);
    }

    private void StartLevel(LevelParameters level)
    {
        BulletPool.Clear();
        player.gameObject.SetActive(true);
        ChangeLevel(level);
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
        player.gameObject.SetActive(false);
        uiController.ShowEndLevelUI(
            generator.IsChestOpened ? EndLevelUIState.COMPLETE : EndLevelUIState.LOST, 
            Time.realtimeSinceStartup - levelStartTime, selectedLevel
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
        GlobalEvents.Subscribe(EventName.LevelWon, EndLevel);
    }

    private void OnDisable()
    {
        player.onBulletShot.RemoveListener(OnBulletShot);
        GlobalEvents.Unsubscribe(EventName.BulletDestroyed, OnBulletDestroyed);
        GlobalEvents.Unsubscribe(EventName.RestartLevel, RestartSelectedLevel);
        GlobalEvents.Unsubscribe(EventName.LevelWon, EndLevel);
    }
}
