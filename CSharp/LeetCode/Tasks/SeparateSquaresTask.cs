namespace LeetCode.Tasks;

public class SeparateSquaresTask
{
    public double SeparateSquares(int[][] squares) {

        var sq = squares.OrderBy(x => x[1]).ToList();
        var yy = sq.Select(x => x[1]).ToList();
        var left = (double)sq[0][1];
        var right = (double)sq[^1][1];

        while(true)
        {

        }

        (int, int) Calculate()
        {
            var m = (left + right) / 2;

            var p1 = yy.BinarySearch((int)m);
            if(p1 < 0)
            {
                p1 = ~p1;
            }
            else
            {
                while(p1 > 0 && yy[p1 - 1] == (int)m)
                {
                    p1--;
                }
            }


            var p2 = yy.BinarySearch((int)m + 1);

            return (0, 0);
        }
    }
}


