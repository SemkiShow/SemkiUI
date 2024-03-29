﻿using System;
using System.Collections.Generic;

namespace SemkiUI
{
    public class SemkiUI
    {
        public static int OneChoiceList(string[] List)
        {
            int selectedLine = 0;
            while (true)
            {
                Console.Clear();
                if (selectedLine < 0)
                {
                    selectedLine = 0;
                }
                if (selectedLine >= List.Length)
                {
                    selectedLine = List.Length - 1;
                }
                Console.ResetColor();
                for (int i = 0; i < selectedLine; i++)
                {
                    Console.WriteLine(List[i]);
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(List[selectedLine]);
                Console.ResetColor();
                Console.WriteLine();
                for (int i = selectedLine + 1; i < List.Length; i++)
                {
                    Console.WriteLine(List[i]);
                }
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    // Console.SetCursorPosition(0, Console.CursorTop - List.Length + 1);
                    return selectedLine;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedLine--;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedLine++;
                }
                // Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + List.Length - 1);
            }
        }
        public static List<int> MultipleChoiceList(string[] List)
        {
            int selectedLine = 0;
            List<int> selectedLines = new List<int>{};
            while (true)
            {
                Console.Clear();
                if (selectedLine < 0)
                {
                    selectedLine = 0;
                }
                if (selectedLine >= List.Length)
                {
                    selectedLine = List.Length - 1;
                }
                Console.ResetColor();
                for (int i = 0; i < selectedLine; i++)
                {
                    if (selectedLines.Contains(i))
                    {
                        Console.Write("[X] ");
                    }
                    else
                    {
                        Console.Write("[ ] ");
                    }
                    Console.WriteLine(List[i]);
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                if (selectedLines.Contains(selectedLine))
                {
                    Console.Write("[X] ");
                }
                else
                {
                    Console.Write("[ ] ");
                }
                Console.Write(List[selectedLine]);
                Console.ResetColor();
                Console.WriteLine();
                for (int i = selectedLine + 1; i < List.Length; i++)
                {
                    if (selectedLines.Contains(i))
                    {
                        Console.Write("[X] ");
                    }
                    else
                    {
                        Console.Write("[ ] ");
                    }
                    Console.WriteLine(List[i]);
                }

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    return selectedLines;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedLine--;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedLine++;
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    if (selectedLines.Contains(selectedLine))
                    {
                        selectedLines.RemoveAt(selectedLine);
                    }
                    else
                    {
                        selectedLines.Add(selectedLine);
                    }
                }
            }
        }
        public static void Text(string text, bool newLine, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ResetColor();
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
            if (newLine)
            {
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public static void Progressbar(string currentAction = "", float fill = 0, float size = 10)
        {
            Console.WriteLine("[" + new string('#', Convert.ToInt16(fill)) + new string('.', Convert.ToInt16(size - fill)) + "]" + (fill / size * 100) + "%" + currentAction);
        }
        public static string Password(char symbol = '*')
        {
            string password = "";
            while (true)
            {
                Console.Clear();
                Console.Write("Password: " + new string(symbol, password.Length));
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Q || key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return password;
                    break;
                }
                else
                {
                    password += key.KeyChar.ToString();
                }
            }
        }
        public static void Main()
        {
            Console.WriteLine(OneChoiceList(new string[]{"Test1", "Test2", "Test3", "Test4", "Test5", "Test6", "Test7", "Test8", "Test9", "Test10"}));
            foreach (var item in MultipleChoiceList(new string[]{"Test1", "Test2", "Test3", "Test4", "Test5", "Test6", "Test7", "Test8", "Test9", "Test10"}))
            {
                Console.WriteLine(item);
            }
            Text("Black Text", true, ConsoleColor.Black, ConsoleColor.White);
            Text("Ugly Text", true);
            for (int i = 0; i <= 10; i++)
            {
                Progressbar("", i, 10);
            }
            Console.WriteLine(Password());
        }
    }
}