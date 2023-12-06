using System;
using System.IO;

class Program
{
    // Функція для розбиття числа на цифри
    static int[] SplitDigits(int num)
    {
        System.Collections.Generic.List<int> digits = new System.Collections.Generic.List<int>();
        while (num > 0)
        {
            digits.Add(num % 10);
            num /= 10;
        }
        digits.Reverse();
        return digits.ToArray();
    }

    static void Main()
    {
        StreamReader inputFile = new StreamReader("INPUT.txt");

        if (!inputFile.EndOfStream)
        {
            string line = inputFile.ReadLine();
            string[] numbers = line.Split();

            if (numbers.Length == 2 && int.TryParse(numbers[0], out int S) && int.TryParse(numbers[1], out int K))
            {
                inputFile.Close();

                // Знаходження максимального та мінімального K-значних чисел з заданою сумою S
                int maxNumber = 0, minNumber = 0;
                int CopyS = S;

                // Спочатку формуємо максимальне число
                for (int i = 0; i < K; ++i)
                {
                    int digit = Math.Min(S, 9);
                    maxNumber = maxNumber * 10 + digit;
                    S -= digit;
                }

                int maxNumberCopy = maxNumber;
                int suport = 0;

                // Потім формуємо мінімальне число
                for (int y = 1; y > 0; ++y)
                {
                    maxNumberCopy = maxNumberCopy / 10;
                    suport++;
                    if (maxNumberCopy < 10)
                    {
                        y = -1;
                        minNumber = (maxNumber / maxNumberCopy) + CopyS - 1;
                    }
                }

                StreamWriter outputFile = new StreamWriter("OUTPUT.TXT");

                // Запис відповіді в файл
                outputFile.WriteLine($"{maxNumber} {minNumber}");

                // Закриття вихідного файлу
                outputFile.Close();
            }
            else
            {
                Console.WriteLine("Некоректний формат введених даних");
            }
        }
        else
        {
            Console.WriteLine("Не вдалося зчитати дані з файлу");
        }
    }
}