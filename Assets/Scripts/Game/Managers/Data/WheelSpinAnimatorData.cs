public class WheelSpinAnimatorData
{
    public float spinDuration;
    public float spinsAmount;

    public void Init(GameConfig gameConfig)
    {
        spinDuration = gameConfig.SpinDuration;
        spinsAmount = gameConfig.SpinsAmount;
    }
}