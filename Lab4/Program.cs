using System;
using System.IO;
using ConsoleApp.ClassLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            switch (args[0].ToLower())
            {
                case "version":
                    Console.WriteLine("Автор: Дашковський Сергій");
                    Console.WriteLine("Версія: 1.0.0");
                    break;
                case "run":
                    RunLab(args);
                    break;
                case "set-path":
                    SetLabPath(args);
                    break;
                default:
                    ShowHelp();
                    break;
            }
        }

        static void RunLab(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Необхідно вказати назву лабораторної роботи (lab1, lab2, lab3)");
                return;
            }

            LabRunner labRunner = new LabRunner();
            switch (args[1].ToLower())
            {
                case "lab1":
                    labRunner.RunLab1(args);
                    break;
                case "lab2":
                    labRunner.RunLab2(args);
                    break;
                case "lab3":
                    labRunner.RunLab3(args);
                    break;
                default:
                    Console.WriteLine($"Невідома лабораторна робота: {args[1]}");
                    break;
            }
        }

        static void SetLabPath(string[] args)
        {
            // Логіка для встановлення шляху LAB_PATH
        }

        static void ShowHelp()
        {
            // Вивід довідкової інформації
            Console.WriteLine("Допустимі команди: version, run [lab1|lab2|lab3], set-path");
        }
    }
}
