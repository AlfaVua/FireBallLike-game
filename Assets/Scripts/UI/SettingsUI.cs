using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsUI : BaseUI
{
    [SerializeField] private List<LevelParameters> levelList;
    [SerializeField] private LevelItemLoader levelLoader;
    [SerializeField] private Button closeButton;
    public Button.ButtonClickedEvent CloseClicked => closeButton.onClick;
    public UnityEvent<LevelParameters> OnLevelSelected => levelLoader.onLevelSelected;

    public void Init()
    {
        UpdateLevelSelectionField();
    }

    private void UpdateLevelSelectionField()
    {
        levelLoader.DrawItems(levelList);
    }
}