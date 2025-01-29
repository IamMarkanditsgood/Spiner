using System.Collections.Generic;
using UnityEngine;

public partial class GameController : MonoBehaviour
{
    [SerializeField] private SceneManagersInitializer _sceneManagersInitializer;  
    [SerializeField] private RectTransform _wheel;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private WheelDecorator _wheelCollector;

    private RewardsManager _rewardsManager = new RewardsManager();
    private WheelSpinAnimator _wheelSpinAnimator = new WheelSpinAnimator();
    private GameData _gameData = new GameData();

    private List<GameObject> _textRewards = new List<GameObject>();
    private List<int> _rewards = new List<int>();

    private int _currentReward;

    public class GameData
    {
        public RewardsManagerData rewardsManagerData = new RewardsManagerData();
        public WheelSpinAnimatorData wheelSpinAnimatorData = new WheelSpinAnimatorData();
        public WheelDecoratorData wheelDecoratorData = new WheelDecoratorData();

        public void Init(GameConfig gameConfig)
        {
            rewardsManagerData.Init(gameConfig);
            wheelSpinAnimatorData.Init(gameConfig);
            wheelDecoratorData.Init(gameConfig);
        }
    }

    private void Start()
    {
        _sceneManagersInitializer.ConfigScene();

        _gameData.Init(_gameConfig);

        _rewardsManager.SetRewards(ref _rewards, _gameData.rewardsManagerData);
        _wheelCollector.ConfigWheel(ref _textRewards, _rewards, _gameData.wheelDecoratorData);

        Subscribe();
    }

    private void OnDestroy()
    {
        UnSubscribe();
    }
    
    private void Subscribe()
    {
        GameEvents.OnWheelSpiningStart += StartSpin;
        GameEvents.OnWheelSpiningFinish += FinishSpin;
    }

    private void UnSubscribe()
    {
        GameEvents.OnWheelSpiningStart -= StartSpin;
        GameEvents.OnWheelSpiningFinish -= FinishSpin;
    }

    private void StartSpin()
    {
        int randomRewardIndex = Random.Range(0, _rewards.Count);      
        float finaleRotation = _wheelSpinAnimator.GetFinaleWheelRotation(randomRewardIndex, _gameConfig.SegmentCount);

        _currentReward = _rewards[randomRewardIndex];

        StartCoroutine(_wheelSpinAnimator.SpinWheel(_wheel, finaleRotation, _gameData.wheelSpinAnimatorData));
    }

    private void FinishSpin()
    {
        ResourcesManager.Instance.ModifyResource(ResourceTypes.Coins, _currentReward);
    }
}