using System;
using System.Collections.Generic;
using System.Linq;

class Program {
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

    static void Main() {
        var calendar = new MyCalendar();
        Console.WriteLine($"Book(0, 10): {calendar.Book(0, 10)} (expected: True)");
        Console.WriteLine($"Book(10, 20): {calendar.Book(10, 20)} (expected: True)");
        Console.WriteLine($"Book(0, 5): {calendar.Book(0, 5)} (expected: False)");
        Console.WriteLine();

        var calendar2 = new MyCalendar();
        Console.WriteLine("Booking even intervals 0,2,4,6,8...");
        for (int i = 0; i < 10; i += 2) {
            var result = calendar2.Book(i, i + 1);
            Console.WriteLine($"  Book({i}, {i+1}): {result} (expected: True)");
            if (!result) break;
        }
        Console.WriteLine("Booking odd intervals 1,3,5,7,9...");
        for (int i = 1; i < 10; i += 2) {
            var result = calendar2.Book(i, i + 1);
            Console.WriteLine($"  Book({i}, {i+1}): {result} (expected: True)");
            if (!result) break;
        }
        Console.WriteLine($"Book(0, 1) again: {calendar2.Book(0, 1)} (expected: False)");
    }
}

