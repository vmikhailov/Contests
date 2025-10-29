using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        s = s.Replace(" ","");
        var l = s.Length;
        if(l <= 2) return s;
        
        var r = (int)Math.Sqrt(l);
        var c = (l - 1) / r + 1;
        
        var ss = "";
        for(var i = 0; i < r; i++)
        {
            var p = i * c;
            var q = Math.Min(p + c, s.Length);
            ss += s[p..q] + "\n";
        }
        return ss[..^1];
    }

}

class SolutionTask1
{
    public static void Execute()
    {
        var s = "if man was meant to stay on the ground god would have given us roots";
        //var s = "have a nice day1";
        string result = Result.encryption(s);
        Console.WriteLine(result);
    }
}

class SolutionTask2
{
    public static void Execute1()
    {
        int[] arr = [3, 4, 5, 1, 2, 3, 1];

        var max = 0;
        var count = 0;
        for(var i = 0; i < arr.Length; i++)
        {
            if (arr[i] <= max) continue;

            max = arr[i];
            count++;
        }
        Console.WriteLine(count);
    }
    
    public static void Execute2()
    {
        int[] arr = [7, 4, 5, 1, 2, 3, 1];

        var max = 0;
        var count = 0;
        foreach(var a in arr.Reverse().Where(x => x > max))
        {
            max = a;
            count++;
        }
        Console.WriteLine(count);
    }
    
    public static void Execute()
    {
        int[] arr = [13, 4, 5, 1, 2, 3, 1];
        var max = 0;
        var count = arr.Reverse().Where(x => x > max).Select(x => max = x).Count();
        
        Console.WriteLine(count);
    }
}