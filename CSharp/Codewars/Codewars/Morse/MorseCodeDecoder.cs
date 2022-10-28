using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Codewars.Morse
{
    public class MorseCodeDecoder
    {
        
        private string _bits;
        private static readonly MorseNode Morse;

        private static readonly (char symbol, string code)[] Codes = new[]
        {
            ('a', ".-"), ('b', "-..."), ('c', "-.-."), ('d', "-.."), ('e', "."), ('f', "..-."), ('g', "--."), ('h', "...."),
            ('i', ".."), ('j', ".---"), ('k', "-.-"), ('l', ".-.."), ('m', "--"), ('n', "-."), ('o', "---"), ('p', ".--."),
            ('q', "--.-"), ('r', ".-."), ('s', "..."), ('t', "-"), ('u', "..-"), ('v', "...-"), ('w', ".--"), ('x', "-..-"),
            ('y', "-.--"), ('z', "--.."), ('0', "-----"), ('1', ".----"), ('2', "..---"), ('3', "...--"), ('4', "....-"),
            ('5', "....."), ('6', "-...."), ('7', "--..."), ('8', "---.."), ('9', "----."), ((char)0x01, "...---..."), ('!', "-.-.--"),
            ('.', ".-.-.-")
        };

        private List<int> _zeros;
        private List<int> _ones;

        static MorseCodeDecoder()
        {
            Morse = new MorseNode();
            foreach (var c in Codes)
            {
                Morse.Add(c.symbol, c.code);
            }
        }
        
        public MorseCodeDecoder(string bits)
        {
            var d = new Dictionary<string, string>();
            _bits = bits;
        }

        public static string Encode(string morseCode)
        {
            var sb = new StringBuilder();
            foreach (var c in morseCode)
            {
                if (c == ' ')
                {
                    sb.Append("   ");
                    continue;
                }

                foreach (var cc in Codes)
                {
                    if (char.ToUpper(cc.symbol) == c)
                    {
                        sb.Append(cc.code);
                    }
                }

                sb.Append(" ");
            }

            return sb.ToString();
        }
        
        public static string DecodeBitsAdvanced(string bits)
        {
            var decoder = new MorseCodeDecoder(bits);
            decoder.Split();
            return decoder.Decode();
        }

        public string Decode()
        {
            if (!_ones.Any()) return "";
            if (!_zeros.Any()) return ".";

            var all = _zeros.Concat(_ones).OrderBy(x => x).ToList();
            var median = all.Average();

            var k = 20;
            for (var i = 0; i < k; i++)
            {
                var m = median + i / 2 * (i % 2 * 2 - 1) / 2.0;
                if (CanDecode(m))
                {
                    median = m;
                    break;
                }
            }
            
            _zeros.Add(0);
            
            var dotTime = all.Where(x => x <= median).Average();
            var dotDelta = median - dotTime;
            var pauseTime = dotTime * 7 - dotDelta;

            var signals = _ones.Select(x => x <= median ? "." : "-").ToList();
            var pauses = _zeros.Select(x => x <= median ? "" : x <= pauseTime ? " " : "   ").ToList();
            
            var result = string.Concat(signals.Zip(pauses, (s, p) => s + p));
            
            return result;
        }

        public static string Decode(string morseCode)
        {
            var words = morseCode.Split("   ");

            string Parse(string x)
            {
                var r = string.Concat(x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Morse.Decode));
                if (r.Length > 0)
                {
                    return r[0] switch
                    {
                        (char)0x01 => "SOS" + r[1..],
                        _ => r
                    };
                }
                else
                {
                    return null;
                }
            }

            var result = string.Join(" ", words.Select(Parse).Where(x => x != null));

            return result.ToUpper();
        }

        public (List<int> zeros, List<int> ones) Split()
        {
            var bits = _bits.Trim('0');
            
            _zeros = new List<int>();
            _ones = new List<int>();
            var count = 1;
            if (string.IsNullOrEmpty(bits)) return (_zeros, _ones);
            var prev = bits[0];

            for (var i = 1; i <= bits.Length; i++)
            {
                var c = i < bits.Length ? bits[i] : (char)0;
                if (c == prev)
                {
                    count++;
                }
                else
                {
                    var list = prev == '0' ? _zeros : _ones;
                    list.Add(count);
                    prev = c;
                    count = 1;
                }
            }

            return (_zeros, _ones);
        }
      
        private bool CanDecode(double median)
        {
            var signals = _ones.Select(x => x <= median ? 0 : 1).ToArray();
            var pauses = _zeros.Select(x => x > median).ToArray();
            
            var current = new List<int>();
            for (var i = 0; i < signals.Length; i++)
            {
                current.Add(signals[i]);
                if (i == pauses.Length || pauses[i])
                {
                    if (!Morse.CanDecode(current)) return false;
                    current.Clear();
                }
            }

            return true;
        }


        public static string DecodeBits(string bits)
        {
            var decoder = new MorseCodeDecoder(bits);
            var (zeros, ones) = decoder.Split();
            if (!ones.Any()) return "";

            var k = 1;
            if (zeros.Any())
            {
                var m = zeros.Max();
                var d = zeros.Distinct().Count() switch
                {
                    3 => 7,
                    2 => 3,
                    1 => 1,
                    _ => 0,
                };
                k = d > 0 ? m / d : 1;
                k = Math.Min(k, ones.Min());
            }
            else
            {
                k = ones.Min();
            }

            bits = bits.Trim('0');
            var sb = new StringBuilder();
            for (var i = 0; i < bits.Length / k; i++)
            {
                sb.Append(bits[i * k]);
            }

            sb.Replace("111", "-");
            sb.Replace("1", ".");
            sb.Replace("0000000", "   ");
            sb.Replace("000", " ");
            sb.Replace("0", "");
            return sb.ToString();
        }
    }
}