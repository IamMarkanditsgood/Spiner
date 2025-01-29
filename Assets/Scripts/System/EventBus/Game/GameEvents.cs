using System;

public static class GameEvents
{
    public static event Action OnWheelSpiningFinish;
    public static event Action OnWheelSpiningStart;

    public static void FinishWheelSpin() => OnWheelSpiningFinish?.Invoke();
    public static void StartWheelSpin() => OnWheelSpiningStart?.Invoke();
}