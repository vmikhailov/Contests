namespace LeetCode.Tasks2025;

public interface ILFUCache
{
    int Get(int key);
    void Put(int key, int value);
}

