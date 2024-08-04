using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private LevelParameters selectedLevel;
    [SerializeField] private PlayerController player;
    [SerializeField] private LevelGenerator generator;
    [SerializeField] private UIController uiController;

    private float levelStartTime;

    private void Awake()
    {
        GameControls.Init();
    }

    private void Start()
    {
        Start(selectedLevel);
    }

    private void Start(LevelParameters level)
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
    }

    private void EndLevel()
    {
        uiController.ShowGameOverUI(Time.realtimeSinceStartup - levelStartTime);
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
