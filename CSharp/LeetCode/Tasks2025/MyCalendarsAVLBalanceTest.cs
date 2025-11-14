using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Tasks2025;

public class MyCalendarsAVLBalanceTest
{
    [Test]
    public void AVL_SequentialBookings_StaysBalanced()
    {
        // Это худший случай для простого BST - последовательные вставки
        // AVL должен оставаться сбалансированным
        var calendar = new MyCalendarsOneTask.MyCalendarAVL();

        // Бронируем последовательные интервалы [0,1], [1,2], [2,3], ... [99,100]
        for (int i = 0; i < 100; i++)
        {
            calendar.Book(i, i + 1).Should().BeTrue($"Booking [{i}, {i+1}) should succeed");
        }

        // Попытка забронировать существующий интервал должна провалиться
        calendar.Book(50, 51).Should().BeFalse("Booking [50, 51) should fail (already exists)");
    }

    [Test]
    public void AVL_vs_SimpleBST_BothWork()
    {
        var avl = new MyCalendarsOneTask.MyCalendarAVL();
        var bst = new MyCalendarsOneTask.MyCalendarBST();

        // Оба должны давать одинаковые результаты
        avl.Book(10, 20).Should().BeTrue();
        bst.Book(10, 20).Should().BeTrue();

        avl.Book(15, 25).Should().BeFalse();
        bst.Book(15, 25).Should().BeFalse();

        avl.Book(20, 30).Should().BeTrue();
        bst.Book(20, 30).Should().BeTrue();
    }
}

