using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private ChestModel bonusChest;
    [SerializeField][Min(1)] private float platformsStartingOffsetY = 1;

    private List<GameObject> platforms = new List<GameObject>();

    public bool IsChestOpened => bonusChest.GetHealth() == 0;

    public void Init(LevelParameters levelParams)
    {
        bonusChest.Init(levelParams.ChestParameters);
        ResetChestPosition(levelParams.PlatformAmount);
        GeneratePlatforms(levelParams.PlatformAmount);
    }

    private void GeneratePlatforms(int amount)
    {
        ClearPlatforms();
        while (platforms.Count != amount)
        {
            GeneratePlatform(platforms.Count);
        }
    }

    private void ResetChestPosition(float height)
    {
        var chestPosition = bonusChest.transform.position;
        var y = container.position.y + height * platformsStartingOffsetY;
        bonusChest.transform.position = new Vector3(chestPosition.x, y, chestPosition.z);
    }

    private void GeneratePlatform(float y)
    {
        var platform = Instantiate(platformPrefab, Vector3.zero, Quaternion.identity, container);
        platform.transform.localPosition = y * platformsStartingOffsetY * Vector3.up;
        platforms.Add(platform);
    }

    private void ClearPlatforms()
    {
        platforms.ForEach(Destroy);
        platforms.Clear();
    }
}
