namespace LeetCode.Tasks;

public class StringDiv
{
    public string GcdOfStrings(string str1, string str2) {
        int i = 0;
        while(i < str1.Length && i < str2.Length && str1[i] == str2[i]) i++;
        
        if(i == 0) return "";
        
        var t = str1[..i];
        if(!MadeOf(str1, t)) return "";
        if(!MadeOf(str2, t)) return "";
        return t;
    }

    bool MadeOf(ReadOnlySpan<char> w, ReadOnlySpan<char> t)
    {
        if(w.Length == 0) return true;
        if(w.Length >= t.Length && w[..t.Length].SequenceEqual(t)) return MadeOf(w[t.Length..], t);
        return false;
    }
}