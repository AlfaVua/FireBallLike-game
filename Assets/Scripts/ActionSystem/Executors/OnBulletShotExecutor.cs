using System;
using UnityEngine;

public class OnBulletShotExecutor : BaseExecutor
{
    [SerializeField] private PlayerController player;

    private void OnBulletShot(int bullets)
    {
        Execute();
    }
    
    private void OnEnable()
    {
        player.onBulletShot.AddListener(OnBulletShot);
    }

    private void OnDisable()
    {
        player.onBulletShot.RemoveListener(OnBulletShot);
    }
}