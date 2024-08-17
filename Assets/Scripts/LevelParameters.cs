using UnityEngine;

[CreateAssetMenu(fileName = "LevelPrefab", menuName = "Level/Prefab")]
public class LevelParameters : ScriptableObject
{
    [SerializeField] private int bulletsAmount;
    [SerializeField] private int platforms;
    [SerializeField] private int[] secondsForStar;
    [SerializeField] private ChestProperties chest;
    [SerializeField] private string title;
    public int BulletsAmount => bulletsAmount;
    public int PlatformAmount => platforms;
    public int[] SecondsForStar => secondsForStar;
    public ChestProperties ChestParameters => chest;
    public string Title => title;
}
