using System;
using System.Text;

public static class Lab1
{
    public static string Run(string inputFile)
    {
        try
        {
            // Зчитуємо вхідні дані
            string input = inputFile;
            int s = int.Parse(input.Split(' ')[0]);
            int k = int.Parse(input.Split(' ')[1]);

            // Отримання відповіді
            var response = SatelliteResponse(s, k);

            // Форматування вихідних даних
            return $"{response.max} {response.min}";
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

    private static (string max, string min) SatelliteResponse(int s, int k)
    {
        StringBuilder maxNumber = new StringBuilder(new string('0', k));
        StringBuilder minNumber = new StringBuilder(new string('0', k));

        int remainingSum = s;

        // Формування максимального числа
        for (int i = 0; i < k; i++)
        {
            if (remainingSum > 9)
            {
                maxNumber[i] = '9';
                remainingSum -= 9;
            }
            else
            {
                maxNumber[i] = (char)(remainingSum + '0');
                remainingSum = 0;
            }
        }

        remainingSum = s;

        // Формування мінімального числа
        for (int i = k - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                minNumber[i] = (char)(remainingSum + '0');
            }
            else
            {
                if (remainingSum > 9)
                {
                    minNumber[i] = '9';
                    remainingSum -= 9;
                }
                else
                {
                    minNumber[i] = (char)((remainingSum - 1) + '0');
                    minNumber[0] = '1';
                    break;
                }
            }
        }

        return (maxNumber.ToString(), minNumber.ToString());
    }
}
