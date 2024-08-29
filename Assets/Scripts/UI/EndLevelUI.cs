using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EndLevelUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI playTimeText;
    [SerializeField] private TextMeshProUGUI stateText;
    [SerializeField] private Button closeButton;
    [SerializeField] private StarPanelUI stars;

    public Button.ButtonClickedEvent CloseClicked => closeButton.onClick;

    public void Draw(EndLevelUIState state, float playTime, LevelParameters level)
    {
        DrawState(state);
        SetFinishTime(playTime);
        ShowStars(playTime, level);
    }

    private void ShowStars(float playTime, LevelParameters level)
    {
        for (int i = 0; i < level.SecondsForStar.Length; i++)
        {
            if (i == level.SecondsForStar.Length || level.SecondsForStar[i] < playTime)
            {
                stars.ShowStars(i);
                return;
            }
        }
    }

    private void DrawState(EndLevelUIState state)
    {
        stateText.text = state switch
        {
            EndLevelUIState.LOST => "Game Lost",
            _ => "Level Complete"
        };
    }
    
    private void SetFinishTime(float _playTime)
    {
        var time = TimeSpan.FromSeconds(_playTime);
        playTimeText.text = time.ToString("hh':'mm':'ss");
    }
}

public enum EndLevelUIState
{
    LOST,
    COMPLETE
}
