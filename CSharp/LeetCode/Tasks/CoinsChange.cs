namespace LeetCode.Tasks;

public class CoinsChange
{
    public int CoinChange(int[] coins, int amount) {
        if(amount == 0) return 0;
        return Solve(coins, coins.Length - 1, amount);
    }

    private int Solve(int[] coins, int m, int amount)
    {
        for(var i = m; i >= 0; i--)
        {
            if (coins[i] == amount)
            {
                return 1;
            }
            
            if(coins[i] < amount)
            {
                var v = Solve(coins, m, amount - coins[i]);
                if(v >= 0) return v + 1;
            }
        }
        return -1;
    }
}