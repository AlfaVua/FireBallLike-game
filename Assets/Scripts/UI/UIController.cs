using UnityEngine;
using UnityEngine.Serialization;

public class UIController : MonoBehaviour
{
    [SerializeField] private MainGameUI mainGameUI;
    [SerializeField] private EndLevelUI endLevelUI;
    [SerializeField] private MainUI mainUI;
    [SerializeField] private SettingsUI settingsUI;
    public MainGameUI GameUI => mainGameUI;
    private BaseUI _activeUI;

    public void Init(GameController gameController)
    {
        mainUI.Init(this);
        settingsUI.Init();
        ShowMainUI();
        AddListeners(gameController);
    }

    private void AddListeners(GameController gameController)
    {
        endLevelUI.CloseClicked.AddListener(ShowMainUI);
        settingsUI.CloseClicked.AddListener(ShowMainUI);
        settingsUI.OnLevelSelected.AddListener(gameController.ChangeLevel);
    }

    public void ShowGameUI()
    {
        ShowUI(mainGameUI);
    }

    public void ShowEndLevelUI(EndLevelUIState state, float endTime, LevelParameters level)
    {
        ShowUI(endLevelUI);
        endLevelUI.Draw(state, endTime, level);
    }

    public void ShowMainUI()
    {
        ShowUI(mainUI);
    }

    public void ShowSettingsUI()
    {
        ShowUI(settingsUI);
    }

    private void ShowUI(BaseUI ui)
    {
        if (_activeUI) _activeUI.Hide();
        _activeUI = ui;
        _activeUI.Show();
    }
}
