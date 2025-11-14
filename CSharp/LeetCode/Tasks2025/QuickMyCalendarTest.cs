using NUnit.Framework;
using FluentAssertions;
using LeetCode.Tasks2025;

namespace LeetCode.Tests;

public class QuickMyCalendarTest
{
    [Test]
    public void QuickTest()
    {
        var cal = new MyCalendarsOneTask.MyCalendarAVL();
        cal.Book(10, 20).Should().BeTrue();
        cal.Book(15, 25).Should().BeFalse();
        cal.Book(20, 30).Should().BeTrue();
    }
}

