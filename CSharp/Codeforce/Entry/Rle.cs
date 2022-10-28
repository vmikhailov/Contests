using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Entry
{
    public class Rle
    {
        
        public static int[] Compress(int[] array)
        {
            var list = new List<int>();
            var p = array[0];
            var k = 1;
            list.Add(p);
            foreach (var v in array.Skip(1))
            {
                if (v == p)
                {
                    k++;
                    continue;
                }
                list.Add(k);
                list.Add(p = v);
                k = 1;
            }
            list.Add(k);

            return list.ToArray();
        }
        
        public static void Main1()
        {
            var n = int.Parse(Console.ReadLine());
            var v = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var compressed = Compress(v);
            Console.WriteLine(compressed.Length/2);
            for (var i = 0; i < compressed.Length - 1; i += 2)
            {
                Console.WriteLine($"{compressed[i]} {compressed[i+1]}");
            }
        }
    }
}