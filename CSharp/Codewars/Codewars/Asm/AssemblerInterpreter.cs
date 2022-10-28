using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Codewars.Asm
{
    internal class AssemblerInterpreter
    {
        private readonly IDictionary<string, int> _regs = new Dictionary<string, int>();
        private readonly Dictionary<string, Func<string[], (Action action, int address)>> _commands;
        private readonly Stack<int> _stack;
        private readonly Stack<int> _callStack;
        private readonly string _text;
        private string _message;
        private string _result;

        public enum Action
        {
            Next,
            Jump,
            Call,
            Return
        }

        public static string Interpret(string input)
        {
            return new AssemblerInterpreter(input).Run();
        }

        private AssemblerInterpreter(string text)
        {
            _text = text;
            Labels = new Dictionary<string, int>();
            Lines = new List<(string, string[])>();
            _commands = new Dictionary<string, Func<string[], (Action, int)>>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "mov", a => Op(a, (x, y) => y) },
                { "inc", a => Op(a, (x, y) => x + 1) },
                { "dec", a => Op(a, (x, y) => x - 1) },
                { "add", a => Op(a, (x, y) => x + y) },
                { "sub", a => Op(a, (x, y) => x - y) },
                { "mul", a => Op(a, (x, y) => x * y) },
                { "div", a => Op(a, (x, y) => x / y) },
                { "jne", a => Jmp(a, x => x != 0) },
                { "je", a => Jmp(a, x => x == 0) },
                { "jge", a => Jmp(a, x => x >= 0) },
                { "jg", a => Jmp(a, x => x > 0) },
                { "jle", a => Jmp(a, x => x <= 0) },
                { "jl", a => Jmp(a, x => x < 0) },
                { "jmp", a => (Action.Jump, Labels[a[0]]) },
                { "call", a => (Action.Call, Labels[a[0]]) },
                { "ret", a => (Action.Return, 1) },
                { "cmp", Cmp },
                { "msg", Msg },
                { "end", End },
            };
            _stack = new Stack<int>();
            _callStack = new Stack<int>();
        }

        public IList<(string command, string[] args)> Lines { get; }
        public IDictionary<string, int> Labels { get; }

        public string Run()
        {
            PreProcess();
            RunImpl();
            return _result;
        }

        private void RunImpl()
        {
            var i = 0;
            while (i >= 0 && i < Lines.Count)
            {
                var r = _commands[Lines[i].command](Lines[i].args);

                if (r.action == Action.Call) _callStack.Push(i + 1);

                i = r.action switch
                {
                    Action.Next => i + 1,
                    Action.Jump => r.address,
                    Action.Call => r.address,
                    Action.Return => r.address == -1 ? -1 : _callStack.Pop(),
                    _ => -1
                };
            }
        }

        private void PreProcess()
        {
            var countLines = 0;

            foreach (var line in _text.Split("\n"))
            {
                var cleanedChars = line.SkipWhile(x => x == ' ')
                                       .TakeWhile(x => x != ';')
                                       .Reverse()
                                       .SkipWhile(x => x == ' ')
                                       .Reverse()
                                       .ToArray();

                if (!cleanedChars.Any()) continue;

                if (cleanedChars[^1] == ':')
                {
                    var name = cleanedChars[..^1];
                    Labels.Add(new string(name), countLines);
                }
                else
                {
                    var commandChars = cleanedChars.TakeWhile(x => x != ' ').ToArray();
                    var argsChars = cleanedChars.SkipWhile(x => x != ' ')
                                                .SkipWhile(x => x == ' ').ToArray();
                    var argsList = new List<string>();
                    var sb = new StringBuilder();
                    var stringArg = false;
                    foreach (var c in argsChars)
                    {
                        if (!stringArg)
                        {
                            if (c == ' ') continue;
                            if (c == ',')
                            {
                                argsList.Add(sb.ToString());
                                sb.Clear();
                                continue;
                            }
                        }
                        sb.Append(c);
                    
                        if (c == '\'')
                        {
                            stringArg = !stringArg;
                        }
                    }

                    argsList.Add(sb.ToString());
                
                    Lines.Add((new string(commandChars), argsList.ToArray()));
                    countLines++;
                }
            }
        }

        private static T GetAt<T>(T[] arr, int index)
        {
            return index < 0 || index >= arr.Length ? default : arr[index];
        }

        #region AsmCommands

        private (Action, int) Op(string[] args, Func<int, int, int> operation)
        {
            _regs[args[0]] = operation(GetRegister(args[0]), GetRegisterOrValue(GetAt(args, 1)));

            return (Action.Next, 1);
        }

        private (Action, int) Jmp(string[] args, Func<int, bool> condition)
        {
            var label = args[0];
            var val = _stack.Pop();

            return condition(val) ? (Action.Jump, Labels[label]) : (Action.Next, 0);
        }
    
        private (Action, int) Cmp(string[] args)
        {
            _stack.Push(GetRegisterOrValue(args[0]) - GetRegisterOrValue(args[1]));

            return (Action.Next, 1);
        }

        private (Action, int) Msg(string[] args)
        {
            var sb = new StringBuilder();
            foreach (var arg in args)
            {
                var val = arg.Trim('\'');
                if (arg.Length - 2 != val.Length && _regs.TryGetValue(arg, out var num))
                {
                    sb.Append(num);
                }
                else
                {
                    sb.Append(val);
                }
            }

            _message = sb.ToString();

            return (Action.Next, 1);
        }

        private (Action, int) End(string[] args)
        {
            _result = _message;

            return (Action.Return, -1);
        }

        private int GetRegisterOrValue(string arg)
        {
            return arg == null ? 0 : int.TryParse(arg, out var num) ? num : GetRegister(arg);
        }

        private int GetRegister(string arg)
        {
            return _regs.TryGetValue(arg, out var num) ? num : 0;
        }

        #endregion
    }
}