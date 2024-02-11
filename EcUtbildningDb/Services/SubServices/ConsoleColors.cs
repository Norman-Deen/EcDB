

using System;

namespace EcDB.Services.SubServices
{
    public static class ConsoleColors
    {
        public static void PrintColoredLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}

