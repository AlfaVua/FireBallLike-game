using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private MainGameUI mainGameUI;
    [SerializeField] private GameOverUI gameOverUI;
    public MainGameUI GameUI => mainGameUI;
    private BaseUI activeUI;

    public void ShowGameUI()
    {
        ShowUI(mainGameUI);
    }

    public void ShowGameOverUI(float endTime)
    {
        ShowUI(gameOverUI);
        gameOverUI.SetFinishTime(endTime);
    }

    private void ShowUI(BaseUI ui)
    {
        if (activeUI) activeUI.Hide();
        activeUI = ui;
        activeUI.Show();
    }
}
