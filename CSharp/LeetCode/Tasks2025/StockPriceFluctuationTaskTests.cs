using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

/**
 * Your StockPrice object will be instantiated and called as such:
 * StockPrice obj = new StockPrice();
 * obj.Update(timestamp,price);
 * int param_2 = obj.Current();
 * int param_3 = obj.Maximum();
 * int param_4 = obj.Minimum();
 */
[TestFixture]
public class StockPriceFluctuationTaskTests
{
    private StockPriceFluctuationTask _stock = null!;

    [SetUp]
    public void SetUp() => _stock = new StockPriceFluctuationTask();

    [Test]
    public void Update_SinglePrice_CurrentReturnsPrice()
    {
        _stock.Update(1, 10);
        _stock.Current().Should().Be(10);
    }

    [Test]
    public void Update_MultiplePrices_CurrentReturnsLatestTimestamp()
    {
        _stock.Update(1, 10);
        _stock.Update(2, 5);
        _stock.Update(3, 15);
        _stock.Current().Should().Be(15);
    }

    [Test]
    public void Update_OutOfOrder_CurrentReturnsLatestTimestamp()
    {
        _stock.Update(5, 50);
        _stock.Update(2, 20);
        _stock.Update(8, 80);
        _stock.Update(3, 30);
        _stock.Current().Should().Be(80); // timestamp 8 is latest
    }

    [Test]
    public void Update_SameTimestamp_CurrentUpdatesPrice()
    {
        _stock.Update(1, 10);
        _stock.Update(2, 20);
        _stock.Update(1, 15); // Update timestamp 1
        _stock.Current().Should().Be(20); // timestamp 2 is still latest
    }

    [Test]
    public void Maximum_SinglePrice_ReturnsPrice()
    {
        _stock.Update(1, 10);
        _stock.Maximum().Should().Be(10);
    }

    [Test]
    public void Maximum_MultiplePrices_ReturnsHighest()
    {
        _stock.Update(1, 10);
        _stock.Update(2, 50);
        _stock.Update(3, 30);
        _stock.Update(4, 20);
        _stock.Maximum().Should().Be(50);
    }

    [Test]
    public void Minimum_SinglePrice_ReturnsPrice()
    {
        _stock.Update(1, 10);
        _stock.Minimum().Should().Be(10);
    }

    [Test]
    public void Minimum_MultiplePrices_ReturnsLowest()
    {
        _stock.Update(1, 10);
        _stock.Update(2, 5);
        _stock.Update(3, 30);
        _stock.Update(4, 20);
        _stock.Minimum().Should().Be(5);
    }

    [Test]
    public void Update_Correction_UpdatesMaximum()
    {
        _stock.Update(1, 10);
        _stock.Update(2, 100); // max
        _stock.Update(3, 30);
        _stock.Maximum().Should().Be(100);

        _stock.Update(2, 5); // Correct timestamp 2

        // After correction, max should change
        _stock.Maximum().Should().NotBe(100);
    }

    [Test]
    public void Update_Correction_UpdatesMinimum()
    {
        _stock.Update(1, 50);
        _stock.Update(2, 5); // min
        _stock.Update(3, 30);
        _stock.Minimum().Should().Be(5);

        _stock.Update(2, 100); // Correct timestamp 2

        // After correction, min should change
        _stock.Minimum().Should().NotBe(5);
    }

    [Test]
    public void ComplexScenario_Example1_WorksCorrectly()
    {
        _stock.Update(1, 10);
        _stock.Current().Should().Be(10);
        _stock.Maximum().Should().Be(10);
        _stock.Minimum().Should().Be(10);

        _stock.Update(2, 5);
        _stock.Current().Should().Be(5);
        _stock.Maximum().Should().Be(10);
        _stock.Minimum().Should().Be(5);

        _stock.Update(1, 3); // Correct timestamp 1
        _stock.Current().Should().Be(5); // timestamp 2 is still latest
        _stock.Maximum().Should().Be(5);
        _stock.Minimum().Should().Be(3);
    }

    [Test]
    public void ComplexScenario_Example2_WorksCorrectly()
    {
        _stock.Update(1, 10);
        _stock.Update(2, 5);
        _stock.Maximum().Should().Be(10);

        _stock.Update(1, 3); // Correct timestamp 1
        _stock.Maximum().Should().Be(5);

        _stock.Update(4, 2);
        _stock.Minimum().Should().Be(2);
        _stock.Maximum().Should().Be(5);
        _stock.Current().Should().Be(2);
    }

    [Test]
    public void Update_MultipleCorrections_SameTimestamp_WorksCorrectly()
    {
        _stock.Update(1, 100);
        _stock.Maximum().Should().Be(100);

        _stock.Update(1, 50); // First correction
        _stock.Update(1, 25); // Second correction
        _stock.Update(1, 75); // Third correction

        _stock.Current().Should().Be(75);
        _stock.Maximum().Should().Be(75);
        _stock.Minimum().Should().Be(75);
    }

    [Test]
    public void Update_LargeValues_HandlesCorrectly()
    {
        _stock.Update(1, 1000000);
        _stock.Update(2, 999999);
        _stock.Update(3, 1000001);

        _stock.Maximum().Should().Be(1000001);
        _stock.Minimum().Should().Be(999999);
        _stock.Current().Should().Be(1000001);
    }

    [Test]
    public void Update_SequentialTimestamps_WorksCorrectly()
    {
        for (int i = 1; i <= 10; i++)
        {
            _stock.Update(i, i * 10);
        }

        _stock.Current().Should().Be(100); // timestamp 10, price 100
        _stock.Maximum().Should().Be(100);
        _stock.Minimum().Should().Be(10);
    }

    [Test]
    public void Update_ReverseOrder_WorksCorrectly()
    {
        _stock.Update(10, 100);
        _stock.Update(5, 50);
        _stock.Update(1, 10);

        _stock.Current().Should().Be(100); // timestamp 10 is latest
        _stock.Maximum().Should().Be(100);
        _stock.Minimum().Should().Be(10);
    }

    [Test]
    public void Update_SamePrices_DifferentTimestamps_WorksCorrectly()
    {
        _stock.Update(1, 50);
        _stock.Update(2, 50);
        _stock.Update(3, 50);

        _stock.Current().Should().Be(50);
        _stock.Maximum().Should().Be(50);
        _stock.Minimum().Should().Be(50);
    }

    [Test]
    public void Update_ZeroPrice_HandlesCorrectly()
    {
        _stock.Update(1, 0);
        _stock.Update(2, 10);

        _stock.Minimum().Should().Be(0);
        _stock.Maximum().Should().Be(10);
        _stock.Current().Should().Be(10);
    }

    [Test]
    public void Update_AlternatingHighLow_WorksCorrectly()
    {
        _stock.Update(1, 100);
        _stock.Update(2, 10);
        _stock.Update(3, 90);
        _stock.Update(4, 20);
        _stock.Update(5, 80);

        _stock.Current().Should().Be(80);
        _stock.Maximum().Should().Be(100);
        _stock.Minimum().Should().Be(10);
    }
}
