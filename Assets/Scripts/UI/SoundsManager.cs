using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioConfig _buttonConfig;
    [SerializeField] private AudioManager _audioManager;

    public static SoundsManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PressButton()
    {
        _audioManager.PlayOneShot(_buttonConfig);
    }
}
