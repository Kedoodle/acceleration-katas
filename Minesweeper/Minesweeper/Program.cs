﻿using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleFieldGenerator = new ConsoleFieldGenerator();
            ConsoleFieldGenerator.Generate();
        }
    }
}