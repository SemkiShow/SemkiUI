using System;
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
                if (selectedLine < 0)
                {
                    selectedLine = 0;
                }
                if (selectedLine >= List.Length)
                {
                    selectedLine = List.Length - 1;
                }
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
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
            }
        }
        public static List<int> MultipleChoiceList(string[] List)
        {
            int selectedLine = 0;
            List<int> selectedLines = new List<int>{};
            while (true)
            {
                Console.Clear();
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

                if (selectedLine < 0)
                {
                    selectedLine = 0;
                }
                if (selectedLine >= List.Length)
                {
                    selectedLine = List.Length - 1;
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
        }
    }
}