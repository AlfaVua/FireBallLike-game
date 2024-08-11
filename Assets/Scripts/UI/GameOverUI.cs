using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI playTime;
    [SerializeField] private TextMeshProUGUI stateText;
    [SerializeField] private Button closeButton;

    public Button.ButtonClickedEvent CloseClicked => closeButton.onClick;

    public void Draw(OverUIState state, float playTime)
    {
        DrawState(state);
        SetFinishTime(playTime);
    }

    private void DrawState(OverUIState state)
    {
        stateText.text = state switch
        {
            OverUIState.LOST => "Game Lost",
            _ => "Level Complete"
        };
    }
    
    private void SetFinishTime(float _playTime)
    {
        var time = TimeSpan.FromSeconds(_playTime);
        playTime.text = time.ToString("hh':'mm':'ss");
    }
}

public enum OverUIState
{
    LOST,
    COMPLETE
}
