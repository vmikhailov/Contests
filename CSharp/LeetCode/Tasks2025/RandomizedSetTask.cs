namespace LeetCode.Tasks2025;

public class RandomizedSetTask
{
    public class RandomizedSet
    {
        private readonly Dictionary<int, int> _storage = [];
        private readonly List<int> _ids = [];
        private int _count;

        public bool Insert(int val)
        {
            if (!_storage.TryAdd(val, _count))
            {
                return false;
            }

            _ids.Add(val);
            _count++;
            return true;
        }

        public bool Remove(int val)
        {
            if (!_storage.Remove(val, out var id))
            {
                return false;
            }

            if (id < _count - 1)
            {
                var last = _ids[_count - 1];
                _ids[id] = last;
                _storage[last] = id;
                _ids.RemoveAt(_count - 1);
            }
            else
            {
                _ids.RemoveAt(id);
            }
            _count--;
            return true;

        }

        public int GetRandom()
        {
            var i = Random.Shared.Next(_count);
            return _ids[i];
        }
    }
}
