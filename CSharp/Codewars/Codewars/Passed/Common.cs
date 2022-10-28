namespace Codewars.Codewars.Passed
{
    public class Common
    {
        public int GCD(int a, int b) 
        {
            while (a % b > 0)  
            {
                var r = a % b;
                a = b;
                b = r;
            }
            
            return b;
        }

        public int GCD(params int[] numbers)
        {
            return GCD(numbers[0], 1, numbers);
        }
        
        private int GCD(int x, int i, int[] numbers)
        {
            x = GCD(x, numbers[i]);

            return i < numbers.Length - 1 ? GCD(x, i + 1, numbers) : x;
        }

        public int LCM(int a, int b) => a * b / GCD(a, b);
    }
}