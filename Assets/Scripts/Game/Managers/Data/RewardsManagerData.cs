public class RewardsManagerData
{
    public int segmentAmount;
    public int minRewardValue;
    public int maxRewardValue;
    public int numberMultiplicity;
    public int minInterval;

    public void Init(GameConfig gameConfig)
    {
        segmentAmount = gameConfig.SegmentCount;
        minRewardValue = gameConfig.MinRewardValue;
        maxRewardValue = gameConfig.MaxRewardValue;
        numberMultiplicity = gameConfig.NumberMultiplicity;
        minInterval = gameConfig.MinInterval;
    }
}