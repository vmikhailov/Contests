namespace LeetCode.Tasks2025;

public class RansomNoteTask
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var f1 = ransomNote.ToLookup(x => x).ToDictionary(x => x.Key, x => x.Count());
        var f2 = magazine.ToLookup(x => x).ToDictionary(x => x.Key, x => x.Count());

        foreach(var (k,v) in f1)
        {
            if (!f2.TryGetValue(k, out var v2) || v2 < v)
            {
                return false;
            }
        }

        Queue<int> q = new Queue<int>();

        return true;
    }
}
