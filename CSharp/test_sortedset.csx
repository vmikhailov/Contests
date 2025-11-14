using System;
using System.Collections.Generic;

var events = new SortedSet<(int start, int end)>();

// Test 1: Empty calendar, book first event
events.Add((10, 20));
Console.WriteLine("After adding (10, 20):");
Console.WriteLine($"  Count: {events.Count}");

// Test 2: Try to find next event >= 15
var view = events.GetViewBetween((15, 0), (int.MaxValue, int.MaxValue));
if (view.Count > 0) {
    var next = view.Min;
    Console.WriteLine($"  Next event >= 15: ({next.start}, {next.end})");
    Console.WriteLine($"  Would reject [15, 25]? {next.start < 25}");
}

// Test 3: Try to book adjacent event [20, 30]
Console.WriteLine("\nTrying to book [20, 30]:");
var view2 = events.GetViewBetween((20, 0), (int.MaxValue, int.MaxValue));
if (view2.Count > 0) {
    var next = view2.Min;
    Console.WriteLine($"  Next event >= 20: ({next.start}, {next.end})");
    Console.WriteLine($"  Would reject? {next.start < 30}");
} else {
    Console.WriteLine("  No next event found");
}

// Check previous
if (events.Max.start < 20) {
    var prev = events.GetViewBetween((0, 0), (19, int.MaxValue));
    if (prev.Count > 0) {
        var last = prev.Max;
        Console.WriteLine($"  Previous event: ({last.start}, {last.end})");
        Console.WriteLine($"  Would reject? {last.end > 20}");
    }
} else {
    Console.WriteLine("  Max start is >= 20, checking differently...");
}

// Test 4: Book at 0
events.Clear();
events.Add((0, 10));
Console.WriteLine("\n\nAfter adding (0, 10):");
Console.WriteLine($"  Count: {events.Count}");
Console.WriteLine($"  Max start: {events.Max.start}");

// Try to book [0, 5]
Console.WriteLine("Trying to book [0, 5]:");
var view3 = events.GetViewBetween((0, 0), (int.MaxValue, int.MaxValue));
if (view3.Count > 0) {
    var next = view3.Min;
    Console.WriteLine($"  Next event >= 0: ({next.start}, {next.end})");
    Console.WriteLine($"  Would reject? {next.start < 5}");
}

