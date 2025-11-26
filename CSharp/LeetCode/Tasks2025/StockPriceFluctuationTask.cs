namespace LeetCode.Tasks2025;

/*
   You are given a stream of records about a particular stock. Each record contains a timestamp and the
   corresponding price of the stock at that timestamp.

   Unfortunately due to the volatile nature of the stock market, the records do not come in order.
   Even worse, some records may be incorrect. Another record with the same timestamp may appear later in the stream correcting the price of the previous wrong record.

   Design an algorithm that:

   Updates the price of the stock at a particular timestamp,
   correcting the price from any previous records at the timestamp.
   Finds the latest price of the stock based on the current records.
   The latest price is the price at the latest timestamp recorded.

   Finds the maximum price the stock has been based on the current records.
   Finds the minimum price the stock has been based on the current records.
   Implement the StockPrice class:

   StockPrice() Initializes the object with no price records.
   void update(int timestamp, int price) Updates the price of the stock at the given timestamp.
   int current() Returns the latest price of the stock.
   int maximum() Returns the maximum price of the stock.
   int minimum() Returns the minimum price of the stock.
 */

public class StockPriceFluctuationTask
{
    private readonly Dictionary<int, int> _timeToPrice = [];
    private readonly PriorityQueue<(int price, int ts), (int p, int ts)> _min = new();
    private readonly PriorityQueue<(int price, int ts), (int p, int ts)> _max = new();
    private int _currentTs;

    public void Update(int timestamp, int price)
    {
        _timeToPrice[timestamp] = price;
        if (timestamp > _currentTs) _currentTs = timestamp;

        // min-heap: приоритет (price, ts)
        _min.Enqueue((price, timestamp), (price, timestamp));
        // max-heap через инверсию приоритета: (-price, -ts) — бОльшая цена «меньше»
        _max.Enqueue((price, timestamp), (-price, -timestamp));
    }

    public int Current() => _timeToPrice[_currentTs];

    private int GetTop(PriorityQueue<(int price, int ts), (int p, int ts)> q)
    {
        while (q.Count > 0)
        {
            var value = q.Peek();
            if (_timeToPrice.TryGetValue(value.ts, out var cur) && cur == value.price)
            {
                return value.price;
            }
            q.Dequeue();
        }
        return 0;
    }

    public int Maximum() => GetTop(_max);

    public int Minimum() => GetTop(_min);
}
