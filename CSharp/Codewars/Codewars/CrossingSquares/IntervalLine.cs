using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.CrossingSquares
{
    public class IntervalLine<TK, TV>
        where TK : IComparable<TK>
    {
        public IList<TK> Keys { get; }

        public IList<ISet<TV>> Values { get; }

        public IntervalLine()
        {
            Keys = new List<TK>();
            Values = new List<ISet<TV>>();
        }

        public void AddInterval(TK from, TK to, TV value)
        {
            var i1 = GetValues(from);
            var i2 = GetValues(to);

            for (var i = i1; i <= i2; i++)
            {
                Values[i].Add(value);
            }
        }

        public ISet<TV> GetIntersections(TK from, TK to)
        {
            var v1 = Values[GetValues(from)];
            var v2 = Values[GetValues(to)];
            return v1.Union(v2).ToHashSet();
        }

        private int GetValues(TK key)
        {
            var i = FindKey(key);
            if (i < 0)
            {
                i = -i - 1;
                Keys.Insert(i, key);
                Values.Insert(i, null);
                var v1 = i > 0 ? Values[i - 1] : null;
                var v2 = i < Values.Count - 1 ? Values[i + 1] : null;
                Values[i] = v1 == null || v2 == null ? new HashSet<TV>() : v1.Intersect(v2).ToHashSet();
            }

            return i;
        }

        public int FindKey(TK key)
        {
            return FindKey(key, 0, Keys.Count);
        }

        private int FindKey(TK key, int l, int r)
        {
            var m = (l + r) / 2;

            if (l == r) return -m - 1;
            switch (key.CompareTo(Keys[m]))
            {
                case 1: return FindKey(key, m + 1, r);
                case -1: return FindKey(key, l, m);
                default:
                    return m;
            }
        }

        public void RemoveInterval(TK from, TK to, TV value)
        {
            var i1 = GetValues(from);
            var i2 = GetValues(to);

            for (var i = i1; i <= i2; i++)
            {
                Values[i].Remove(value);
            }
        }
    }
}