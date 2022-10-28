using System;
using System.Collections.Generic;

namespace Codewars.Codewars.Asm
{
    public static class SimpleAssembler
    { 
        private static readonly Dictionary<string, int> vars = new Dictionary<string, int>();
        
        public static Dictionary<string, int> Interpret(string[] program)
        {
            var commands = new Dictionary<string, Func<string, string, int>>()
            {
                { "mov", Mov },
                { "inc", Inc },
                { "dec", Dec },
                { "jnz", Jnz },
            };

            vars.Clear();
            var i = 0;
            while (i < program.Length)
            {
                var cc = program[i].Split(" ");
                i += commands[cc[0]](GetAt(cc,1), GetAt(cc,2));
            }

            return vars;
        }

        private static void Dump(string[] program)
        {
            for (var i = 0; i < program.Length; i++)
            {
                var c = program[i];
                var n = $"inst_{i}_{program[i]}";
                vars[n] = 1;
            }
        }

        private static int Mov(string arg1, string arg2)
        {
            if (!int.TryParse(arg2, out var num))
            {
                num = GetValue(arg2);
            }

            vars[arg1] = num;

            return 1;
        }

        private static int Inc(string arg1, string arg2)
        {
            vars[arg1] = GetValue(arg1) + 1;

            return 1;
        }

        private static int Jnz(string arg1, string arg2)
        {
            int.TryParse(arg2, out var offset);
            var val = int.TryParse(arg1, out var num) ? num : GetValue(arg1);

            return val != 0 ? offset : 1;
        }

        private static int Dec(string arg1, string arg2)
        {
            vars[arg1] = GetValue(arg1) - 1;

            return 1;
        }

        private static int GetValue(string arg)
        {
            return vars.TryGetValue(arg, out var num) ? num : 0;
        }
        
        private static T GetAt<T>(T[] arr, int index)
        {
            return index < 0 || index >= arr.Length ? default : arr[index];
        }
    }
}