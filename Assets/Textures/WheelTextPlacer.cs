using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WheelTextPlacer : MonoBehaviour
{
    [Header("Параметри колеса")]
    [SerializeField] private int segmentCount = 6; // Кількість сегментів
    [Range(1, 1000)]
    [SerializeField] private float radius = 250f; // Відстань тексту від центру
    [SerializeField] private GameObject textPrefab; // Префаб TMP_Text
    [SerializeField] private RectTransform wheelCenter; // Центр колеса
    [SerializeField] private List<string> rewards; // Написи на сегментах

    private void Start()
    {
        PlaceTexts();
    }

    private void PlaceTexts()
    {
        if (rewards.Count != segmentCount)
        {
            Debug.LogError("Кількість виграшів має відповідати кількості сегментів!");
            return;
        }

        float angleStep = 360f / segmentCount; // Кут між сегментами

        for (int i = 0; i < segmentCount; i++)
        {
            // Створюємо новий текстовий елемент
            GameObject newTextObj = Instantiate(textPrefab, wheelCenter);
            RectTransform textRect = newTextObj.GetComponent<RectTransform>();

            if (textRect == null)
            {
                Debug.LogError("Префаб тексту не містить RectTransform!");
                return;
            }

            TextMeshProUGUI textComponent = newTextObj.GetComponent<TextMeshProUGUI>();
            textComponent.text = rewards[i];

            // Обчислюємо позицію тексту у локальних координатах UI
            float angle = -i * angleStep; // Розташування за годинниковою стрілкою
            Vector2 position = new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad) * radius,
                Mathf.Sin(angle * Mathf.Deg2Rad) * radius
            );

            textRect.anchoredPosition = position; // Встановлюємо позицію в UI
            textRect.localRotation = Quaternion.Euler(0, 0, angle); // Повертаємо текст

            // Налаштовуємо візуальний центр тексту (щоб він дивився назовні)
            textRect.pivot = new Vector2(0.5f, 0.5f);
        }
    }
}
