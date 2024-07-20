using UnityEngine;

public static class Utils
{
    public static bool IsInLayer(this LayerMask mask, int layer)
    {
        return (mask & (1 << layer)) != 0;
    }
}