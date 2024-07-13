using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private int generateAmount = 10;
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Transform bonusChest;
    [SerializeField][Min(1)] private float platformsStartingOffsetY = 1;

    private List<GameObject> platforms;
    private void Start()
    {
        platforms = new List<GameObject>();
        ResetChestPosition(generateAmount);
        GeneratePlatforms(generateAmount);
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
        var y = container.position.y + height * platformsStartingOffsetY;
        bonusChest.position = new Vector3(bonusChest.position.x, y, bonusChest.position.z);
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
