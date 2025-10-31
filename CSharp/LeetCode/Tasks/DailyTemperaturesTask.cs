using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class DailyTemperaturesTask
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        // monotonic stack

        var n = temperatures.Length;
        var result = new int[n];
        var stack = new Stack<int>(); // stores indices

        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int prev = stack.Pop();
                result[prev] = i - prev;
            }

            stack.Push(i);
        }

        return result;
    }
}

[TestFixture]
public class DailyTemperatureTaskTests
{
    private DailyTemperaturesTask _task = null!;

    [SetUp]
    public void SetUp() => _task = new DailyTemperaturesTask();

    [Test]
    public void DailyTemperatures_Basic()
    {
        int[] input = [73, 74, 75, 71, 69, 72, 76, 73];
        int[] expected = [1, 1, 4, 2, 1, 1, 0, 0];
        ClassicAssert.AreEqual(expected, _task.DailyTemperatures(input));
    }

    [Test]
    public void DailyTemperatures_AllDecreasing_ReturnsZeros()
    {
        int[] input = [5, 4, 3, 2, 1];
        int[] expected = [0, 0, 0, 0, 0];
        ClassicAssert.AreEqual(expected, _task.DailyTemperatures(input));
    }

    [Test]
    public void DailyTemperatures_Empty_ReturnsEmpty()
    {
        var input = Array.Empty<int>();
        var expected = Array.Empty<int>();
        ClassicAssert.AreEqual(expected, _task.DailyTemperatures(input));
    }
}
