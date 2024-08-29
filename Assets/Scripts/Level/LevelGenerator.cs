using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private ChestModel chestPrefab;
    [SerializeField][Min(1)] private float platformsStartingOffsetY = 1;

    private ChestModel activeChest;

    private List<GameObject> platforms = new List<GameObject>();

    public bool IsChestOpened => activeChest.IsHealthAtZero;

    public void Init(LevelParameters levelParams)
    {
        if (activeChest)
        {
            Destroy(activeChest.gameObject);
        }
        activeChest = Instantiate(chestPrefab, transform);
        activeChest.Init(levelParams.ChestParameters);
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

    private void ResetChestPosition(float totalPlatforms)
    {
        var containerPosition = container.transform.position;
        var y = container.position.y + totalPlatforms * platformsStartingOffsetY;
        activeChest.transform.position = new Vector3(containerPosition.x, y, containerPosition.z);
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
