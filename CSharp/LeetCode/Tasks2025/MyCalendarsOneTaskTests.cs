using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class MyCalendarsOneTaskTests
{
    [Test]
    public void Book_FirstEvent_ReturnsTrue()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();

        // Act
        var result = calendar.Book(10, 20);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void Book_NonOverlappingEvents_ReturnsTrue()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();
        calendar.Book(10, 20);

        // Act & Assert
        calendar.Book(20, 30).Should().BeTrue();
        calendar.Book(5, 10).Should().BeTrue();
        calendar.Book(30, 40).Should().BeTrue();
    }

    [Test]
    public void Book_OverlappingEvents_ReturnsFalse()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();
        calendar.Book(10, 20);

        // Act & Assert
        calendar.Book(15, 25).Should().BeFalse();
        calendar.Book(5, 15).Should().BeFalse();
        calendar.Book(12, 18).Should().BeFalse();
    }

    [Test]
    public void Book_CompletelyContainedEvent_ReturnsFalse()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();
        calendar.Book(10, 30);

        // Act
        var result = calendar.Book(15, 25);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Book_CompletelyContainingEvent_ReturnsFalse()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();
        calendar.Book(15, 25);

        // Act
        var result = calendar.Book(10, 30);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Book_SameStartTime_ReturnsFalse()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();
        calendar.Book(10, 20);

        // Act
        var result = calendar.Book(10, 15);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Book_SameEndTime_ReturnsFalse()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();
        calendar.Book(10, 20);

        // Act
        var result = calendar.Book(15, 20);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Book_AdjacentEvents_ReturnsTrue()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();
        calendar.Book(10, 20);

        // Act & Assert
        calendar.Book(0, 10).Should().BeTrue();
        calendar.Book(20, 30).Should().BeTrue();
    }

    [Test]
    public void Book_LeetCodeExample1_WorksCorrectly()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();

        // Act & Assert
        // ["MyCalendar", "book", "book", "book"]
        // [[], [10, 20], [15, 25], [20, 30]]
        // Output: [null, true, false, true]
        calendar.Book(10, 20).Should().BeTrue();
        calendar.Book(15, 25).Should().BeFalse();
        calendar.Book(20, 30).Should().BeTrue();
    }

    [Test]
    public void Book_MultipleNonOverlappingEvents_AllReturnTrue()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();

        // Act & Assert
        calendar.Book(5, 10).Should().BeTrue();
        calendar.Book(15, 20).Should().BeTrue();
        calendar.Book(25, 30).Should().BeTrue();
        calendar.Book(10, 15).Should().BeTrue();
        calendar.Book(0, 5).Should().BeTrue();
        calendar.Book(30, 40).Should().BeTrue();
    }

    [Test]
    public void Book_InterleavedBookings_WorksCorrectly()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();

        // Act & Assert
        calendar.Book(20, 30).Should().BeTrue();
        calendar.Book(10, 20).Should().BeTrue();
        calendar.Book(5, 10).Should().BeTrue();
        calendar.Book(30, 40).Should().BeTrue();
        calendar.Book(15, 25).Should().BeFalse(); // Overlaps with 20-30
        calendar.Book(0, 5).Should().BeTrue();
        calendar.Book(40, 50).Should().BeTrue();
    }

    [Test]
    public void Book_SingleTimeUnit_WorksCorrectly()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();

        // Act & Assert
        calendar.Book(10, 11).Should().BeTrue();
        calendar.Book(11, 12).Should().BeTrue();
        calendar.Book(10, 11).Should().BeFalse(); // Duplicate
        calendar.Book(9, 11).Should().BeFalse(); // Overlaps with 10-11
    }

    [Test]
    public void Book_LargeTimeRanges_WorksCorrectly()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();

        // Act & Assert
        calendar.Book(1000, 2000).Should().BeTrue();
        calendar.Book(0, 1000).Should().BeTrue();
        calendar.Book(2000, 3000).Should().BeTrue();
        calendar.Book(500, 1500).Should().BeFalse(); // Overlaps
        calendar.Book(1500, 2500).Should().BeFalse(); // Overlaps
    }

    [Test]
    public void Book_ZeroStartTime_WorksCorrectly()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();

        // Act & Assert
        calendar.Book(0, 10).Should().BeTrue();
        calendar.Book(10, 20).Should().BeTrue();
        calendar.Book(0, 5).Should().BeFalse();
    }

    [Test]
    public void Book_ManySmallEvents_WorksCorrectly()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();

        // Act & Assert - Book even intervals
        for (int i = 0; i < 100; i += 2)
        {
            calendar.Book(i, i + 1).Should().BeTrue();
        }

        // Try to book odd intervals (should work)
        for (int i = 1; i < 100; i += 2)
        {
            calendar.Book(i, i + 1).Should().BeTrue();
        }

        // Try to book any interval now (should fail)
        calendar.Book(0, 1).Should().BeFalse();
        calendar.Book(50, 51).Should().BeFalse();
        calendar.Book(0, 100).Should().BeFalse();
    }

    [Test]
    public void Book_PartialOverlapAtStart_ReturnsFalse()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();
        calendar.Book(20, 30);

        // Act
        var result = calendar.Book(15, 25);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Book_PartialOverlapAtEnd_ReturnsFalse()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();
        calendar.Book(10, 20);

        // Act
        var result = calendar.Book(15, 25);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Book_ExactDuplicate_ReturnsFalse()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();
        calendar.Book(10, 20);

        // Act
        var result = calendar.Book(10, 20);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void Book_ComplexScenario_WorksCorrectly()
    {
        // Arrange
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();

        // Act & Assert - Build a complex schedule
        calendar.Book(47, 50).Should().BeTrue();
        calendar.Book(33, 41).Should().BeTrue();
        calendar.Book(39, 45).Should().BeFalse(); // Overlaps with 33-41
        calendar.Book(33, 42).Should().BeFalse(); // Overlaps with 33-41
        calendar.Book(25, 32).Should().BeTrue();
        calendar.Book(26, 35).Should().BeFalse(); // Overlaps with 25-32 and 33-41
        calendar.Book(19, 25).Should().BeTrue();
        calendar.Book(3, 8).Should().BeTrue();
        calendar.Book(8, 13).Should().BeTrue();
        calendar.Book(18, 27).Should().BeFalse(); // Overlaps with 19-25 and 25-32
    }
}

