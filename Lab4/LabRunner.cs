using System;

namespace ConsoleApp.ClassLibrary
{
    public class LabRunner
    {
        public void RunLab1(string[] args)
        {
            // Адаптування коду lab1 для роботи з аргументами командного рядка
            string inputPath = GetArgumentValue(args, "-i", "--input", "INPUT.txt");
            string outputPath = GetArgumentValue(args, "-o", "--output", "OUTPUT.txt");
            Program1.Main(inputPath, outputPath);
        }

        public void RunLab2(string[] args)
        {
            // Адаптування коду lab2 для роботи з аргументами командного рядка
            string inputPath = GetArgumentValue(args, "-i", "--input", "INPUT.txt");
            string outputPath = GetArgumentValue(args, "-o", "--output", "OUTPUT.txt");
            Program2.Main(inputPath, outputPath);
        }

        public void RunLab3(string[] args)
        {
            // Адаптування коду lab3 для роботи з аргументами командного рядка
            string inputPath = GetArgumentValue(args, "-i", "--input", "INPUT.txt");
            string outputPath = GetArgumentValue(args, "-o", "--output", "OUTPUT.txt");
            Program3.Main(inputPath, outputPath);
        }

        private string GetArgumentValue(string[] args, string shortName, string longName, string defaultValue)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == shortName || args[i] == longName)
                {
                    if (i + 1 < args.Length)
                        return args[i + 1];
                }
            }
            return defaultValue;
        }
    }
}
