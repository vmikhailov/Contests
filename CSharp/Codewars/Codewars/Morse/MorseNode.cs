using System.Collections.Generic;

namespace Codewars.Codewars.Morse
{
    public class MorseNode
    {
        private char Symbol { get; set; }
        private MorseNode Dot { get; set; }
        private MorseNode Dash { get; set; }

        public void Add(char symbol, string code)
        {
            Add(symbol, code, 0);
        }

        public char Decode(string code)
        {
            return Decode(code, 0);
        }

        private void Add(char symbol, string code, int i)
        {
            if (i == code.Length)
            {
                Symbol = symbol;
            }
            else
            {
                var next = code[i] == '.' ? Dot ??= new MorseNode() : Dash ??= new MorseNode();
                next.Add(symbol, code, i + 1);
            }
        }

        private char Decode(string code, int i)
        {
            if (i == code.Length) return Symbol;
            var c = code[i] == '.' ? Dot?.Decode(code, i + 1) : Dash?.Decode(code, i + 1);

            return c ?? (char)0;
        }

        public bool CanDecode(IEnumerable<int> code)
        {
            var enumerator = code.GetEnumerator();
            return CanDecode(enumerator);
        }

        private bool CanDecode(IEnumerator<int> enumerator)
        {
            if (!enumerator.MoveNext()) return Symbol != 0;
            var r = enumerator.Current == 0 ? Dot?.CanDecode(enumerator) : Dash?.CanDecode(enumerator);
            return r ?? false;
        }
    }
}