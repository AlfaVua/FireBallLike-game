using UnityEngine;

[CreateAssetMenu(menuName = "Chest/Properties", fileName = "Chest props")]
public class ChestProperties : ScriptableObject
{
    [SerializeField] private float reward;
    [SerializeField][Min(1)] private float health;
}