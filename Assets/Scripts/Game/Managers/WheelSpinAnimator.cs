using System.Collections;
using UnityEngine;

public class WheelSpinAnimator
{
    public float GetFinaleWheelRotation( int rewardIndex, int segmentCount)
    {
        float segmentAngle = 360f / segmentCount;
        float finaleRotation = rewardIndex * segmentAngle;
        finaleRotation += 360 * UnityEngine.Random.Range(2, 5);
        return finaleRotation;
    }

    public IEnumerator SpinWheel(RectTransform wheel, float finaleRotation, WheelSpinAnimatorData wheelSpinAnimatorData)
    {
        float startRotation = wheel.rotation.eulerAngles.z;
        float endRotation = finaleRotation;
        float elapsedTime = 0f;

        while (elapsedTime < wheelSpinAnimatorData.spinDuration)
        {
            float t = Mathf.Clamp01(elapsedTime / wheelSpinAnimatorData.spinDuration);

            float currentRotation = Mathf.LerpAngle(startRotation, endRotation, Mathf.SmoothStep(0f, 1f, t));

            float extraRotation = Mathf.Lerp(0, wheelSpinAnimatorData.spinsAmount * 360f, Mathf.SmoothStep(0f, 1f, t));
            wheel.rotation = Quaternion.Euler(0, 0, currentRotation + extraRotation);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        wheel.rotation = Quaternion.Euler(0, 0, endRotation);
        GameEvents.FinishWheelSpin();
    }
}