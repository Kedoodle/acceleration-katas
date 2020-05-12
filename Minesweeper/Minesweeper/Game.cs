using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Game
    {
        private readonly InputReader _consoleReader;
        private readonly OutputWriter _consoleWriter;
        private readonly IList<Field> _fields;

        public Game(InputReader consoleReader, OutputWriter consoleWriter)
        {
            _consoleReader = consoleReader;
            _consoleWriter = consoleWriter;
            _fields = new List<Field>();
        }
        
        public void Run()
        {
            GetFields();
            WriteFields();
        }

        private void GetFields()
        {
            var dimensions = (string) _consoleReader.ReadLine();
            while (!DoneInputtingFields(dimensions))
            {
                if (!ValidFieldDimensions(dimensions)) return;

                var successfulField = TryGetField(dimensions, out var field);
                if (!successfulField) return;
                _fields.Add(field);
                
                dimensions = (string) _consoleReader.ReadLine();
            }
        }

        private static bool DoneInputtingFields(string input)
        {
            const string doneSignal = "00";
            return input == doneSignal;
        }

        private static bool ValidFieldDimensions(string input)
        {
            return input.Length == 2 &&
                   HasValidWidth(input) &&
                   HasValidHeight(input);
        }

        private static bool HasValidWidth(string input)
        {
            return int.TryParse(input[0].ToString(), out var height) && height > 0;
        }

        private static bool HasValidHeight(string input)
        {
            return int.TryParse(input[1].ToString(), out var width) && width > 0;
        }

        private bool TryGetField(string dimensions, out Field field)
        {
            var width = GetWidth(dimensions);
            var height = GetHeight(dimensions);
            field = new Field(width, height);

            for (var y = 0; y < height; y++)
            {
                var row = (string) _consoleReader.ReadLine();
                if (!ValidRow(row, width)) return false;
                for (var x = 0; x < width; x++)
                {
                    if (row[x] == '*') field.SetMine(x, y);
                }
            }

            return true;
        }
        
        private static int GetWidth(string input)
        {
            return int.Parse(input[1].ToString());
        }
        
        private static int GetHeight(string input)
        {
            return int.Parse(input[0].ToString());
        }

        private static bool ValidRow(string row, int width)
        {
            const char mine = '*';
            const char safe = '.';
            return row.Length == width && row.All(c => c == mine || c == safe);
        }

        private void WriteFields()
        {
            for (var i = 0; i < _fields.Count; i++)
            {
                _consoleWriter.WriteFieldNumber(i+1);
                _consoleWriter.WriteField(_fields[i]);
            }
        }
    }
}