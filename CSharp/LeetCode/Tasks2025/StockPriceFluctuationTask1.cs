namespace LeetCode.Tasks2025;

public class StockPriceFluctuationTask1
{
    private readonly Dictionary<int, int> _prices = [];
    private readonly SortedDictionary<int, int> _priceCount = new(); // price -> count
    private int _latestTimestamp;
    private int _latestPrice;

    public void Update(int timestamp, int price)
    {
        // Update latest
        if (timestamp >= _latestTimestamp)
        {
            _latestPrice = price;
            _latestTimestamp = timestamp;
        }

        // Remove old price if exists
        if (_prices.TryGetValue(timestamp, out var oldPrice))
        {
            DecrementPrice(oldPrice);
        }

        // Add new price
        _prices[timestamp] = price;
        IncrementPrice(price);
    }

    public int Current() => _latestPrice;
    public int Maximum() => _priceCount.Last().Key;
    public int Minimum() => _priceCount.First().Key;

    private void IncrementPrice(int price)
    {
        _priceCount.TryGetValue(price, out var count);
        _priceCount[price] = count + 1;
    }

    private void DecrementPrice(int price)
    {
        if (_priceCount[price] == 1)
            _priceCount.Remove(price);
        else
            _priceCount[price]--;
    }
}
