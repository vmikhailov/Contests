using System;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class HumanTimeFormat
    {
        public static string formatDuration(int seconds)
        {
            if (seconds == 0) return "now";
            var dt = TimeSpan.FromSeconds(seconds);
            var output = new string[]
            {
                Text(dt.Days / 365, "year"),
                Text(dt.Days % 365, "day"),
                Text(dt.Hours, "hour"),
                Text(dt.Minutes, "minute"),
                Text(dt.Seconds, "second")
            };

            output = output.Where(x => x != null).ToArray();
            var first = output[0];

            if (output.Length == 1)
            {
                return first;
            }
            if (output.Length > 2)
            {
                first = string.Join(", ", output[..^1]);
            }

            return $"{first} and {output[^1]}";
        }

        private static string Text(int value, string text)
        {
            if (value > 0)
            {
                var ending = value >= 2 ? "s" : "";

                return $"{value} {text}{ending}";
            }

            return null;
        }
    }
}