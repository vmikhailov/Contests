namespace LeetCode.Tasks;

public class ShortestCompletingWordClass
{
    public string ShortestCompletingWord(string licensePlate, string[] words) {
        var m = licensePlate.ToLower()
                            .Where(x => char.IsLetter(x))
                            .ToLookup(x => x)
                            .ToDictionary(x => x.Key, x => x.Count());

        var mm = words.Select(x => (w:x, d:x.ToLookup(y => y).ToDictionary(y => y.Key, y => y.Count())));

        var r = new List<string>();
        foreach(var (w,d) in mm)
        {
            var match = true;
            foreach(var p in m)
            {
                if(!d.TryGetValue(p.Key, out var a) || a < p.Value)
                {
                    match = false;
                    break;
                }
            }
            if(match) r.Add(w);
        }

        return r.OrderBy(x => x.Length).First();
    }
}
