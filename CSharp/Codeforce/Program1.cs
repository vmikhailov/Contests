using System;
using Codewars.Entry;
using Codewars.FB;

namespace Codewars
{
    class Program1
    {
        static void Main1(string[] args)
        {
            var node = new Node()
            {
                Value = 1,
                Left = new Node()
                {
                    Value = 3,
                    Left = new Node()
                    {
                        Value = 5
                    },
                    Right = new Node()
                    {
                        Value = 11,
                        Right = new Node()
                        {
                            Value = 2
                        }
                    }
                },
                Right = new Node()
                {
                    Value = 13,
                    Left = new Node()
                    {
                        Value = 15
                    },
                    Right = new Node()
                    {
                        Value = 4,
                        Left = new Node()
                        {
                            Value = 8
                        }
                    }
                }
            };
            
            //expected = 5 3 11 2 1 15 13 8 4

            var iter = new Iterator(node);
            while (true)
            {
                var next = iter.Next();
                if (!next.HasValue) break;
                Console.Write($"{next} ");
            }
            Console.WriteLine();
        }
    }
}