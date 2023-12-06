using System;
using System.IO;

namespace ConsoleApp.ClassLibrary
{
    public static class Program3
    {
        public static void Main(string inputPath, string outputPath)
        {
            using (StreamReader inputFile = new StreamReader(inputPath))
            {
                if (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    string[] numbers = line.Split();

                    if (numbers.Length == 2 && int.TryParse(numbers[0], out int S) && int.TryParse(numbers[1], out int K))
                    {
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

                        using (StreamWriter outputFile = new StreamWriter(outputPath))
                        {
                            // Запис відповіді в файл
                            outputFile.WriteLine($"{maxNumber} {minNumber}");
                        }
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
    }
}
