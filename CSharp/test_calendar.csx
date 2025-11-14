using System;
using System.Collections.Generic;
using System.Linq;

public class MyCalendar {
    private readonly SortedDictionary<int, int> _events = new();

    public bool Book(int startTime, int endTime) {
        foreach (var e in _events) {
            if (e.Key >= startTime) {
                if (e.Key < endTime) {
                    return false;
                }
                break;
            }
        }

        foreach (var e in _events.Reverse()) {
            if (e.Key < startTime) {
                if (e.Value > startTime) {
                    return false;
                }
                break;
            }
        }

        _events[startTime] = endTime;
        return true;
    }
}

var calendar = new MyCalendar();
Console.WriteLine($"Book(0, 10): {calendar.Book(0, 10)}"); // Should be true
Console.WriteLine($"Book(10, 20): {calendar.Book(10, 20)}"); // Should be true
Console.WriteLine($"Book(0, 5): {calendar.Book(0, 5)}"); // Should be false

var calendar2 = new MyCalendar();
for (int i = 0; i < 10; i += 2) {
    Console.WriteLine($"Book({i}, {i+1}): {calendar2.Book(i, i + 1)}"); // All should be true
}
for (int i = 1; i < 10; i += 2) {
    Console.WriteLine($"Book({i}, {i+1}): {calendar2.Book(i, i + 1)}"); // All should be true
}
Console.WriteLine($"Book(0, 1) again: {calendar2.Book(0, 1)}"); // Should be false

