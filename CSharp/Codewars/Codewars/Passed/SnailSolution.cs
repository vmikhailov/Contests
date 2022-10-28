namespace Codewars.Codewars.Passed
{
    public class SnailSolution
    {
        public static int[] Snail(int[][] array)
        {
            var n = array.GetLength(0);
            if (n == 0) return new int[0];

            int x = 0, y = 0, z = 0;
            var r = new int[n * n];
            while(z < n*n)
            {
            
                while (x < n && array[y][x] != 0)
                {
                    r[z++] = array[y][x];
                    array[y][x++] = 0;
                }

                x--;
                y++;
            
                while (y < n && array[y][x] != 0)
                {
                    r[z++] = array[y][x];
                    array[y++][x] = 0;
                }
            
                y--;
                x--;
            
                while (x >= 0 && array[y][x] != 0)
                {
                    r[z++] = array[y][x];
                    array[y][x--] = 0;
                }
                x++;
                y--;
            
                while (y >= 0 && array[y][x] != 0)
                {
                    r[z++] = array[y][x];
                    array[y--][x] = 0;
                }

                y++;
                x++;
            }

            return r;
        }
    
        public static int[] Snail2(int[][] array)
        {
            var n = array.GetLength(0);
            if (n == 0) return new int[0];

            int x = 0, y = 0, z = 0;
            var r = new int[n * n];
            while(z < n*n)
            {
                while (x < n && array[y][x] != 0)
                {
                    r[z++] = array[y][x];
                    array[y][x++] = 0;
                }

                x--;
                y++;
            
                while (y < n && array[y][x] != 0)
                {
                    r[z++] = array[y][x];
                    array[y++][x] = 0;
                }
            
                y--;
                x--;
            
                while (x >= 0 && array[y][x] != 0)
                {
                    r[z++] = array[y][x];
                    array[y][x--] = 0;
                }
                x++;
                y--;
            
                while (y >= 0 && array[y][x] != 0)
                {
                    r[z++] = array[y][x];
                    array[y--][x] = 0;
                }

                y++;
                x++;
            }

            return r;
        }
    }
}