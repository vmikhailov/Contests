namespace LeetCode.Tasks;

public class MyCalendar {
    private readonly List<int> _events = [];

    public bool Book(int startTime, int endTime) {
        var i = _events.BinarySearch(startTime);
        var j = _events.BinarySearch(endTime);

        var start = i < 0 ? ~i : i;
        var end = j < 0 ? ~j : j;

        var startInside = i < 0 ? (~i & 1) == 1 : (i & 1) == 0;
        var endInside = j < 0 ? (~j & 1) == 1 : (j & 1) == 0;

        if (!startInside && !endInside)
        {
            _events.Insert(end, endTime);
            _events.Insert(start, startTime);
            return true;
        }

        return false;
    }

    public static void Test()
    {
        var mc = new MyCalendar();
        Console.WriteLine(mc.Book(10, 20)); // return True
        Console.WriteLine(mc.Book(15, 25)); // return False
        Console.WriteLine(mc.Book(20, 30)); // return True
    }
}

