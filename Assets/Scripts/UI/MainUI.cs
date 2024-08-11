using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : BaseUI
{
    [SerializeField] private Button startGame;
    [SerializeField] private Button settings;
    [SerializeField] private Button exit;

    private UIController _controller;

    public void Init(UIController controller)
    {
        _controller = controller;
    }
    
    private void OnStartClick()
    {
        GlobalEvents.Call(EventName.RestartLevel);
    }

    private void OnSettingsClick()
    {
        _controller.ShowSettingsUI();
    }

    private void CloseGame()
    {
#if UNITY_EDITOR
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
#endif
        Application.Quit();
    }

    private void OnEnable()
    {
        startGame.onClick.AddListener(OnStartClick);
        settings.onClick.AddListener(OnSettingsClick);
        exit.onClick.AddListener(CloseGame);
    }

    private void OnDisable()
    {
        startGame.onClick.RemoveListener(OnStartClick);
        settings.onClick.RemoveListener(OnSettingsClick);
        exit.onClick.RemoveListener(CloseGame);
    }
}