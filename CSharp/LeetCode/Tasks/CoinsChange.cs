using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class CoinsChange
{
    public int CoinChange(int[] coins, int amount) {
        if(amount == 0)
        {
            return 0;
        }

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
                if(v >= 0)
                {
                    return v + 1;
                }
            }
        }
        return -1;
    }
}

[TestFixture]
public class CoinsChangeTests
{
    private CoinsChange _task = null!;

    [SetUp]
    public void SetUp() => _task = new CoinsChange();

    [Test]
    public void CoinChange_ExactMatch_ReturnsOne()
    {
        ClassicAssert.AreEqual(1, _task.CoinChange([1, 2, 5], 5));
    }

    [Test]
    public void CoinChange_MultipleCoins_ReturnsMinimum()
    {
        ClassicAssert.AreEqual(3, _task.CoinChange([1, 2, 5], 11));
    }

    [Test]
    public void CoinChange_Impossible_ReturnsMinusOne()
    {
        ClassicAssert.AreEqual(-1, _task.CoinChange([2], 3));
    }

    [Test]
    public void CoinChange_ZeroAmount_ReturnsZero()
    {
        ClassicAssert.AreEqual(0, _task.CoinChange([1], 0));
    }

    [Test]
    public void CoinChange_SingleCoin_ReturnsCorrect()
    {
        ClassicAssert.AreEqual(2, _task.CoinChange([1], 2));
    }
}
