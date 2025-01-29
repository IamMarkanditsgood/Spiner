using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    [SerializeField] private GameObject _segmentPrefab;
    [SerializeField] private int _segmentCount = 16;
    [SerializeField] private int _minRewardValue = 1000;
    [SerializeField] private int _maxRewardValue = 100000;
    [Range(1, 10000)]
    [SerializeField] private int _numberMultiplicity = 100;
    [Range(1, 10000)]
    [SerializeField] private int _minInterval = 1000;
    [Range(1, 1000)]
    [SerializeField] private float _radius = 250f;
    [SerializeField] private float _spinDuration = 5f;
    [SerializeField] private float _spinsAmount = 5f;

    public GameObject SegmentPrefab => _segmentPrefab;
    public int SegmentCount => _segmentCount;
    public int MinRewardValue => _minRewardValue;
    public int MaxRewardValue => _maxRewardValue;
    public int NumberMultiplicity => _numberMultiplicity;
    public int MinInterval => _minInterval;
    public float Radius => _radius;
    public float SpinDuration => _spinDuration;
    public float SpinsAmount => _spinsAmount;
}