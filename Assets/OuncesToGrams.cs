using UnityEngine;
using TMPro;
using System.Globalization;

public class OuncesToGrams : MonoBehaviour
{
    // Поле для введення унцій
    public TMP_InputField ouncesInput;

    // Поле для відображення результату
    public TextMeshProUGUI resultText;

    public void ConvertToGrams()
    {
        // Отримуємо введене число
        string input = ouncesInput.text.Trim().Replace(',', '.');

        // Перевіряємо правильність введення
        if (!double.TryParse(input,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double ounces)
            || double.IsNaN(ounces)
            || double.IsInfinity(ounces)
            || ounces < 0)
        {
            resultText.text = "Введіть коректну кількість унцій.";
            return;
        }

        // Переводимо унції в грами
        double grams = ounces * 28.349523125;

        // Виводимо результат на екран
        resultText.text = "Результат: " +
                          grams.ToString("0.###", CultureInfo.InvariantCulture) + " г";
    }
}