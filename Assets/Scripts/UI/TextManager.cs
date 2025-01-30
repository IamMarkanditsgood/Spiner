using TMPro;
using UnityEngine;

public class TextManager
{
    public void SetText(object message, TMP_Text textRow, bool formatKNumber = false, bool formatMNumber = false, string frontAddedMessage = "", string endAddedMessage = "", bool addToPrevious = false)
    {
        string formattedText = GetFormattedText(message, formatKNumber, formatMNumber);

        if (addToPrevious)
        {
            textRow.text += frontAddedMessage + formattedText + endAddedMessage;
        }
        else 
        {
            textRow.text = frontAddedMessage + formattedText + endAddedMessage;
        }
    }

    public void SetTimerText(TMP_Text textRow, float seconds, bool showHoursAndMinutes = false, string frontAddedMessage = "", string endAddedMessage = "")
    {
        textRow.text = $"{frontAddedMessage}{FormatTime(seconds, showHoursAndMinutes)}{endAddedMessage}";
    }

    private string FormatTime(float seconds, bool showHoursAndMinutes)
    {
        if (showHoursAndMinutes)
        {
            int hours = Mathf.FloorToInt(seconds / 3600);
            int minutes = Mathf.FloorToInt((seconds % 3600) / 60);
            int secs = Mathf.FloorToInt(seconds % 60);

            return hours > 0
                ? $"{hours:D2}:{minutes:D2}:{secs:D2}"
                : $"{minutes:D2}:{secs:D2}";
        }

        int secsOnly = Mathf.FloorToInt(seconds);
        return $"{secsOnly}";
    }

    private string GetFormattedText(object message, bool formatKNumber =false , bool formatMNumber = false)
    {
        if ((formatKNumber || formatMNumber) && message is int number)
        {
            return FormatNumber(number);
        }

        return message.ToString();
    }

    private string FormatNumber(int number)
    {
        if (number >= 1_000_000) // якщо б≥льше м≥льйона, використовуЇмо M
        {
            return (number / 1_000_000f).ToString("0.#") + "M";
        }
        else if (number >= 1000) // якщо б≥льше тис€ч≥, використовуЇмо K
        {
            return (number / 1000f).ToString("0.#") + "K";
        }

        return number.ToString();
    }
}