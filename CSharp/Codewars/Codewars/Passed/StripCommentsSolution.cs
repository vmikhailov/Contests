using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class StripCommentsSolution
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            if(string.IsNullOrEmpty(text)) return text;
            var symbols = commentSymbols.Select(x => x[0]).ToArray();
            return string.Join("\n", text.Split("\n")
                                         .Select(x => StripLine(x, symbols))
                                         .Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        private static string StripLine(string line, char[] commentSymbols)
        {
            var p = line.IndexOfAny(commentSymbols);
            if (p >= 0)
            {
                line = line.Substring(0, p);
            }

            return line.TrimEnd();
        }
    }
}