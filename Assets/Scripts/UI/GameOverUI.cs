using System;
using TMPro;
using UnityEngine;

public class GameOverUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI finishTime;

    public void SetFinishTime(float finishTime)
    {
        var time = TimeSpan.FromSeconds(finishTime);
        this.finishTime.text = time.ToString("hh':'mm':'ss");
    }
}
