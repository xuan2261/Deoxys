﻿using System.Drawing;
using Colorful;
using Deoxys.Core;

namespace Deoxys
{
    public class ConsoleLogger : ILogger
    {
        public void Success(string message)
        {
            WriteLine(message, Color.Aqua, "+");
        }

        public void Error(string message)
        {
            WriteLine(message, Color.Red, "-");
        }

        public void Info(string message)
        {
            WriteLine(message, Color.Gray, "*");
        }

        public void Warning(string message)
        {
            WriteLine(message, Color.Orange, "!");
        }

        private void WriteLine(string message, Color color, string character)
        {
            Console.WriteLineFormatted("[{0}] {1}", color, Color.White, character, message);
        }
    }
}