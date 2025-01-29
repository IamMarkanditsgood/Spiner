using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WheelTextPlacer : MonoBehaviour
{
    [Header("��������� ������")]
    [SerializeField] private int segmentCount = 6; // ʳ������ ��������
    [Range(1, 1000)]
    [SerializeField] private float radius = 250f; // ³������ ������ �� ������
    [SerializeField] private GameObject textPrefab; // ������ TMP_Text
    [SerializeField] private RectTransform wheelCenter; // ����� ������
    [SerializeField] private List<string> rewards; // ������ �� ���������

    private void Start()
    {
        PlaceTexts();
    }

    private void PlaceTexts()
    {
        if (rewards.Count != segmentCount)
        {
            Debug.LogError("ʳ������ �������� �� ��������� ������� ��������!");
            return;
        }

        float angleStep = 360f / segmentCount; // ��� �� ����������

        for (int i = 0; i < segmentCount; i++)
        {
            // ��������� ����� ��������� �������
            GameObject newTextObj = Instantiate(textPrefab, wheelCenter);
            RectTransform textRect = newTextObj.GetComponent<RectTransform>();

            if (textRect == null)
            {
                Debug.LogError("������ ������ �� ������ RectTransform!");
                return;
            }

            TextMeshProUGUI textComponent = newTextObj.GetComponent<TextMeshProUGUI>();
            textComponent.text = rewards[i];

            // ���������� ������� ������ � ��������� ����������� UI
            float angle = -i * angleStep; // ������������ �� ������������ �������
            Vector2 position = new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad) * radius,
                Mathf.Sin(angle * Mathf.Deg2Rad) * radius
            );

            textRect.anchoredPosition = position; // ������������ ������� � UI
            textRect.localRotation = Quaternion.Euler(0, 0, angle); // ��������� �����

            // ����������� ��������� ����� ������ (��� �� ������� ������)
            textRect.pivot = new Vector2(0.5f, 0.5f);
        }
    }
}
