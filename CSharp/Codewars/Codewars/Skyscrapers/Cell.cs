using System.Diagnostics;

namespace Codewars.Codewars.Skyscrapers
{
    [DebuggerDisplay("{ToString()}")]
    public class Cell
    {
        private long _storage;

        public int Count
        {
            get
            {
                var n = 1;
                var c = 0;
                while (n <= _storage)
                {
                    if ((_storage & n) > 0) c++;
                    n = n << 1;
                }

                return c;
            }
        }

        public int Value
        {
            get
            {
                var n = 1;
                var c = 1;
                var v = 0;
                while (n <= _storage)
                {
                    if ((_storage & n) > 0)
                    {
                        if (v != 0) return 0;
                        v = c;
                    }

                    n = n << 1;
                    c++;
                }

                return v;
            }
            set
            {
                _storage = 0;
                Set(value);
            }
        }

        public void Set(int n)
        {
            _storage |= 1L << (n - 1);
        }
        
        public void Remove(int n)
        {
            _storage &= ~(1L << (n - 1));
        }

        
        public bool Intersect(Cell cell)
        {
            var newValue = _storage & cell._storage;
            var changed = newValue != _storage;
            _storage = newValue;
            
            return changed;
        }

        public bool Except(Cell cell)
        {
            var existing = _storage & cell._storage;
            _storage &= ~(existing);
            return existing > 0;
        }

        public bool Contains(int n) => (_storage & (1L << (n - 1))) > 0;


        public override string ToString()
        {
            return string.Join(", ", ToArray());
        }

        public int[] ToArray()
        {
            var n = 1;
            var c = 1;
            var i = 0;
            var list = new int[Count];
            while (n <= _storage)
            {
                if ((_storage & n) > 0)
                {
                    list[i++] = c;
                }

                n = n << 1;
                c++;
            }

            return list;
        }
    }
}