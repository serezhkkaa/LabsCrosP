using System;
using System.IO;
using System.Linq;

namespace ClassLibraryLab5
{
    public static class Lab2
    {
        public static string Run(string inputFile)
        {
            try
            {
                string fileContents = inputFile;
                char[] delimiters = { '\n', ' ' };
                string[] numberStrings = fileContents.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                if (int.TryParse(numberStrings[0], out int n))
                {
                    int[] talkativeness = numberStrings.Skip(1).Select(int.Parse).ToArray();

                    // Сортування балакучості
                    Array.Sort(talkativeness);

                    // Знаходження мінімальної балакучості розбиття
                    int minMaxDifference = talkativeness[n - 1] - talkativeness[0];

                    // Повернення результату
                    return minMaxDifference.ToString();
                }

                throw new Exception("Неправильні дані");
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
