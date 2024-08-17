using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private MainGameUI mainGameUI;
    [SerializeField] private GameOverUI gameOverUI;
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
        gameOverUI.CloseClicked.AddListener(ShowMainUI);
        settingsUI.CloseClicked.AddListener(ShowMainUI);
        settingsUI.OnLevelSelected.AddListener(gameController.ChangeLevel);
    }

    public void ShowGameUI()
    {
        ShowUI(mainGameUI);
    }

    public void ShowGameOverUI(OverUIState state, float endTime)
    {
        ShowUI(gameOverUI);
        gameOverUI.Draw(state, endTime);
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
