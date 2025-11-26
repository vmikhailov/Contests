namespace LeetCode;

public static class MinHeapTest
{
    public static void Test()
    {
        var heap = new MinHeap<int>();
        heap.Push(5);
        heap.Push(3);
        heap.Push(8);
        heap.Push(1);

        Console.WriteLine(heap.Pop()); // 1
        Console.WriteLine(heap.Peek()); // 3
        Console.WriteLine(heap.Pop()); // 3
    }
}
