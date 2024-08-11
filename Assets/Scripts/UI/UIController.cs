using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private MainGameUI mainGameUI;
    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private MainUI mainUI;
    public MainGameUI GameUI => mainGameUI;
    private BaseUI _activeUI;

    public void Init()
    {
        mainUI.Init(this);
        ShowMainUI();
        AddListeners();
    }

    private void AddListeners()
    {
        gameOverUI.CloseClicked.AddListener(ShowMainUI);
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
        
    }

    private void ShowUI(BaseUI ui)
    {
        if (_activeUI) _activeUI.Hide();
        _activeUI = ui;
        _activeUI.Show();
    }
}
