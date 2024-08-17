using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class LevelItem : DrawableItem
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Button clickArea;

    public Button.ButtonClickedEvent OnClick => clickArea.onClick;
    public void Init(LevelParameters level)
    {
        title.text = level.Title;
    }
}