using System;
using System.IO;
using System.Text;

class SatelliteCommunication
{
    static void Main()
    {
        // Читання вхідних даних
        string[] input = File.ReadAllLines("INPUT.TXT");
        int s = int.Parse(input[0].Split(' ')[0]);
        int k = int.Parse(input[0].Split(' ')[1]);

        // Отримання відповіді
        var response = SatelliteResponse(s, k);

        // Запис вихідних даних
        File.WriteAllText("OUTPUT.TXT", $"{response.max} {response.min}");
    }

    static (string max, string min) SatelliteResponse(int s, int k)
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
