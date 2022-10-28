namespace Codewars.Codewars.Passed
{
    public class Line
    {
        public static string WhoIsNext(string[] names, long n)
        {
            var l = 1;
            var k = n - 1;
            while (k >= l * 5)
            {
                k -= l * 5;
                l *= 2;
            }

            return names[k / l];
        }
    }
}