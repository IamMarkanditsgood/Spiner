using System;
using UnityEngine;

[Serializable]
public class SceneManagersInitializer
{
    [SerializeField] private ResourcesManager _resourcesManager;
    [SerializeField] private UIManager _uiManager;

    public void ConfigScene()
    {
        _resourcesManager.Init();
        _uiManager.ShowScreen(ScreenTypes.Game);
    }
}