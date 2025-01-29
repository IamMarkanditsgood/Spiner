using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class WheelDecorator
{
    [SerializeField] private RectTransform wheelCenter;

    private List<float> segmentAngles = new List<float>();

    public void ConfigWheel(ref List<GameObject> textRewards, List<int> _rewards, WheelDecoratorData _wheelDecoratorData)
    {
        float angleStep = 360f / _wheelDecoratorData.segmentCount;

        for (int i = 0; i < _wheelDecoratorData.segmentCount; i++)
        {
            GameObject newTextObj = UnityEngine.Object.Instantiate(_wheelDecoratorData.segmentPrefab, wheelCenter);
            textRewards.Add(newTextObj);

            RectTransform textRect = newTextObj.GetComponent<RectTransform>();

            float angle = -i * angleStep;
            segmentAngles.Add(angle);


            Vector2 position = new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad) * _wheelDecoratorData.radius,
                Mathf.Sin(angle * Mathf.Deg2Rad) * _wheelDecoratorData.radius
            );

            textRect.anchoredPosition = position;
            textRect.localRotation = Quaternion.Euler(0, 0, angle);
            textRect.pivot = new Vector2(0.5f, 0.5f);
        }

        SetText(textRewards, _rewards);
    }

    private void SetText(List<GameObject> textRewards, List<int> _rewards)
    {
        TextManager textManager = new TextManager();
        for (int i = 0; i < textRewards.Count; i++)
        {
            if (i < _rewards.Count)
            {
                TMP_Text rewardText = textRewards[i].GetComponent<TMP_Text>();
                if (rewardText != null)
                {
                    textManager.SetText(_rewards[i], rewardText);
                }
            }
        }
    }
}