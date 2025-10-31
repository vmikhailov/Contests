using NUnit.Framework.Legacy;
using NUnit.Framework;

namespace LeetCode.Tasks;

public class RestoreIp
{
    public IList<string> RestoreIpAddresses(string s)
    {
        var q = new Stack<int>();
        var r = new List<string>();
        Parse(0);
        return r;

        void Parse(int i)
        {
            if (q.Count == 4)
            {
                if (i == s.Length)
                {
                    r.Add(string.Join('.', q.Reverse()));
                }

                return;
            }

            for (var j = i + 1; j <= s.Length; j++)
            {
                var w = s[i..j];
                var v = int.Parse(w);
                if (v > 255)
                {
                    break;
                }

                if (w.Length > 1 && v == 0)
                {
                    continue;
                }

                if (w.StartsWith('0') && v != 0)
                {
                    continue;
                }

                q.Push(v);
                Parse(j);
                q.Pop();
            }
        }
    }
}

[TestFixture]
public class RestoreIpTests
{
    private RestoreIp _task = null!;

    [SetUp]
    public void SetUp() => _task = new RestoreIp();

    [Test]
    public void RestoreIpAddresses_ValidIps_ReturnsAll()
    {
        var result = _task.RestoreIpAddresses("25525511135");
        ClassicAssert.AreEqual(2, result.Count);
        CollectionClassicAssert.Contains(result, "255.255.11.135");
        CollectionClassicAssert.Contains(result, "255.255.111.35");
    }

    [Test]
    public void RestoreIpAddresses_AllZeros_ReturnsOne()
    {
        var result = _task.RestoreIpAddresses("0000");
        ClassicAssert.AreEqual(1, result.Count);
        CollectionClassicAssert.Contains(result, "0.0.0.0");
    }

    [Test]
    public void RestoreIpAddresses_WithLeadingZero_ReturnsValid()
    {
        var result = _task.RestoreIpAddresses("101023");
        ClassicAssert.GreaterOrEqual(result.Count, 1);
    }

    [Test]
    public void RestoreIpAddresses_TooShort_ReturnsEmpty()
    {
        var result = _task.RestoreIpAddresses("123");
        ClassicAssert.AreEqual(0, result.Count);
    }

    [Test]
    public void RestoreIpAddresses_SingleSegment_ReturnsCorrect()
    {
        var result = _task.RestoreIpAddresses("1111");
        ClassicAssert.GreaterOrEqual(result.Count, 1);
    }
}

