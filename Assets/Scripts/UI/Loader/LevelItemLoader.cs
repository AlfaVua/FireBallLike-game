using System.Collections.Generic;
using UnityEngine.Events;

public class LevelItemLoader : ScrollLoader<LevelItem>
{
    public readonly UnityEvent<LevelParameters> onLevelSelected = new UnityEvent<LevelParameters>();
    private LevelParameters selectedLevel;
    public void DrawItems(IEnumerable<LevelParameters> levels)
    {
        RemoveAllItems();
        foreach (var level in levels)
        {
            var item = Instantiate(itemPrefab);
            item.Init(level);
            item.OnClick.AddListener(() =>
            {
                SelectLevel(level);
            });
            AddItem(item);
        }
    }

    private void SelectLevel(LevelParameters level)
    {
        if (level == selectedLevel) return;
        onLevelSelected.Invoke(level);
    }
}