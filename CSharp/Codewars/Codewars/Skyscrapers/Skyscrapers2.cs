using System;
using System.Diagnostics;

namespace Codewars.Codewars.Skyscrapers
{
    public partial class Skyscrapers
    {
        private void Print(string title)
        {
            var k = 0;
            for (var y = 0; y < _n; y++)
            {
                for (var x = 0; x < _n; x++)
                {
                    k = Math.Max(k, _field[x, y].Count);
                }
            }

            var prefix = new string(' ', 3) + "|";
            var line = new string('-', (k * 3 + 2) * _n + 1);
            var cut = new string(' ', 3) + line;

            Debug.WriteLine(new string(' ', 3) + Center(line, title));

            Debug.Write(prefix);
            for (var i = 0; i < _n; i++)
            {
                Debug.Write($"{_clues[i].ToString().PadLeft(k * 3)} |");
            }

            Debug.WriteLine("");
            Debug.WriteLine(cut);
            var i1 = _n * 4 - 1;
            var i2 = _n;

            for (var y = 0; y < _n; y++)
            {
                Debug.Write($"{_clues[i1],2} |");
                for (var x = 0; x < _n; x++)
                {
                    Debug.Write($"{_field[x, y].ToString().PadLeft(k * 3)} |");
                }

                Debug.Write($"{_clues[i2],2}");
                i1--;
                i2++;
                Debug.WriteLine("");
            }

            Debug.WriteLine(cut);
            Debug.Write(prefix);
            for (var i = _n * 3 - 1; i >= _n * 2; i--)
            {
                Debug.Write($"{_clues[i].ToString().PadLeft(k * 3)} |");
            }

            Debug.WriteLine("");
            Debug.WriteLine(cut);
        }

        private string Center(string field, string text)
        {
            if (text.Length > field.Length) text = text.Substring(0, field.Length);
            var i1 = (field.Length - text.Length) / 2;
            var i2 = i1 + text.Length;

            return field.Substring(0, i1) + text + field.Substring(i2, field.Length - i2);
        }
    }
}