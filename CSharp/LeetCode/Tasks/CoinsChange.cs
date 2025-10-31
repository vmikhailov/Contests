using FluentAssertions;
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
        _task.CoinChange([1, 2, 5], 5).Should().Be(1);
    }

    [Test]
    public void CoinChange_MultipleCoins_ReturnsMinimum()
    {
        _task.CoinChange([1, 2, 5], 11).Should().Be(3);
    }

    [Test]
    public void CoinChange_Impossible_ReturnsMinusOne()
    {
        _task.CoinChange([2], 3).Should().Be(-1);
    }

    [Test]
    public void CoinChange_ZeroAmount_ReturnsZero()
    {
        _task.CoinChange([1], 0).Should().Be(0);
    }

    [Test]
    public void CoinChange_SingleCoin_ReturnsCorrect()
    {
        _task.CoinChange([1], 2).Should().Be(2);
    }
}
