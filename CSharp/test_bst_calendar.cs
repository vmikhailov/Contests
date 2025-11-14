using System;

namespace LeetCode.Tasks2025;

public class TestBSTCalendar
{
    public static void Main()
    {
        var calendar = new MyCalendarsOneTask.MyCalendar();

        Console.WriteLine("Test 1: First event");
        Console.WriteLine($"Book(10, 20): {calendar.Book(10, 20)} (expected: True)");

        Console.WriteLine("\nTest 2: LeetCode example");
        var cal2 = new MyCalendarsOneTask.MyCalendar();
        Console.WriteLine($"Book(10, 20): {cal2.Book(10, 20)} (expected: True)");
        Console.WriteLine($"Book(15, 25): {cal2.Book(15, 25)} (expected: False)");
        Console.WriteLine($"Book(20, 30): {cal2.Book(20, 30)} (expected: True)");

        Console.WriteLine("\nTest 3: Non-overlapping events");
        var cal3 = new MyCalendarsOneTask.MyCalendar();
        cal3.Book(10, 20);
        Console.WriteLine($"Book(20, 30): {cal3.Book(20, 30)} (expected: True)");
        Console.WriteLine($"Book(5, 10): {cal3.Book(5, 10)} (expected: True)");
        Console.WriteLine($"Book(30, 40): {cal3.Book(30, 40)} (expected: True)");

        Console.WriteLine("\nTest 4: Overlapping events");
        var cal4 = new MyCalendarsOneTask.MyCalendar();
        cal4.Book(10, 20);
        Console.WriteLine($"Book(15, 25): {cal4.Book(15, 25)} (expected: False)");
        Console.WriteLine($"Book(5, 15): {cal4.Book(5, 15)} (expected: False)");
        Console.WriteLine($"Book(12, 18): {cal4.Book(12, 18)} (expected: False)");

        Console.WriteLine("\nAll tests completed!");
    }
}

