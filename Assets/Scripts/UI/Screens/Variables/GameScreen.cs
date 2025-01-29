using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : BasicScreen
{
    [SerializeField] private Button _spinButton;
    [SerializeField] private TMP_Text _scoreText;

    private TextManager _textManager = new TextManager();

    private void Start()
    {
        Subscribe();
    }

    private void OnDestroy()
    {
        UnSubscribe();
    }

    private void Subscribe()
    {
        _spinButton.onClick.AddListener(StartSpin);

        GameEvents.OnWheelSpiningFinish += SpinFinish;
    }

    private void UnSubscribe()
    {
        _spinButton.onClick.RemoveListener(StartSpin);

        GameEvents.OnWheelSpiningFinish -= SpinFinish;
    }

    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {
        _spinButton.interactable = true;

        int coins = ResourcesManager.Instance.GetResource(ResourceTypes.Coins);
        _textManager.SetText(coins, _scoreText, true, "Score: ");
    }

    private void StartSpin()
    {
        _spinButton.interactable = false;
        GameEvents.StartWheelSpin();
    }

    private void SpinFinish()
    {
        _spinButton.interactable = true;

        int scoreText = ResourcesManager.Instance.GetResource(ResourceTypes.Coins);

        _textManager.SetText(scoreText, _scoreText, true, "Score: ");
    }
}