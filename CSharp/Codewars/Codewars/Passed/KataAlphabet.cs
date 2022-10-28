using System.Linq;

namespace Codewars.Codewars.Passed
{
    public static class KataAlphabet
    {
        public static string AlphabetPosition(string text)
        {
            return string.Join(" ", text.ToLower().Where(x => x >= 'a' && x <= 'z').Select(x => x - 'a' + 1));
        }
    }
}