using System.Collections.Generic;

namespace Codewars.Codewars.Passed
{
    public class IP4Converter
    {
        public static string UInt32ToIP(uint ip)
        {
            var parts = new List<int>();
            for(var i = 0; i< 4; i++)
            {
                parts.Add((int)ip % 256);
                ip = ip / 256;
            }

            parts.Reverse();
            return string.Join(".", parts);
        }
    }
}