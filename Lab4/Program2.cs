using System;
using System.IO;
using System.Linq;

namespace ConsoleApp.ClassLibrary
{
    public static class Program2
    {
        public static void Main(string inputPath, string outputPath)
        {
            // Читання даних з файлу
            string[] lines = File.ReadAllLines(inputPath);
            int n = int.Parse(lines[0]);
            int[] talkativeness = lines[1].Split(' ').Select(int.Parse).ToArray();

            // Сортування балакучості
            Array.Sort(talkativeness);

            // Знаходження мінімальної балакучості розбиття
            int minMaxDifference = talkativeness[n - 1] - talkativeness[0];

            // Запис результату в файл
            File.WriteAllText(outputPath, minMaxDifference.ToString());
        }
    }
}
