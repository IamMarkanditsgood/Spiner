using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : BasicScreen
{
    [SerializeField] private Button _exitGameButton;
    [SerializeField] private Button _startGameButton;

    private const int nextScreenIndex = 1;

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
        _startGameButton.onClick.AddListener(StartGame);
        _exitGameButton.onClick.AddListener(Exit);
    }

    private void UnSubscribe()
    {
        _startGameButton.onClick.RemoveListener(StartGame);
        _exitGameButton.onClick.RemoveListener(Exit);
    }

    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {
    }

    private void StartGame()
    {
        SoundsManager.instance.PressButton();
        SceneManager.LoadSceneAsync(nextScreenIndex);
    }

    private void Exit()
    {
        SoundsManager.instance.PressButton();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}