namespace LeetCode.Tasks;

public class DirectoryServices1
{
    private class Folder
    {
        public string Name;
        public bool Final;
        public IDictionary<string, Folder> Subfolders = new Dictionary<string, Folder>();

        public void Add(string folder)
        {
            var ff = folder.Split('/');
            Add(ff, 1);
        }

        public void TruncateBelowFinals()
        {
            if (Final)
            {
                Subfolders.Clear();
            }
            else
            {
                foreach (var f in Subfolders.Values)
                {
                    f.TruncateBelowFinals();
                }
            }
        }

        public IList<string> Dump()
        {
            var lst = new List<string>();
            var st = new Stack<string>();
            Dump(lst, st);
            return lst;
        }

        private void Dump(IList<string> list, Stack<string> st)
        {
            //if(Final)
            ///{
            //    list.Add(string.Join("/", st.Reverse().Append(Name)));
            //}
            //else
            {
                list.Add(string.Join("/", st.Reverse().Append(Name)) + (Final ? "F" : "NF"));
                st.Push(Name);
                foreach (var f in Subfolders.Values)
                {
                    f.Dump(list, st);
                }

                st.Pop();
            }
        }

        private void Add(string[] folders, int i)
        {
            var name = folders[i];
            if (!Subfolders.TryGetValue(name, out var fld))
            {
                fld = new Folder() { Name = name };
                Subfolders[name] = fld;
            }

            if (i < folders.Length - 1)
            {
                fld.Add(folders, i + 1);
            }
            else
            {
                fld.Final = true;
            }
        }
    }

    public IList<string> RemoveSubfolders(string[] folder)
    {
        var root = new Folder() { Name = "" };

        foreach (var f in folder.Take(1))
        {
            root.Add(f);
        }

        //root.TruncateBelowFinals();

        return root.Dump();
    }
}