using UnityEngine;

public class WheelDecoratorData
{
    public int segmentCount;
    public float radius;
    public GameObject segmentPrefab;

    public void Init(GameConfig gameConfig)
    {
        segmentCount = gameConfig.SegmentCount;
        radius = gameConfig.Radius;
        segmentPrefab = gameConfig.SegmentPrefab;
    }
}