namespace CodeForcesSimple.LeetCode;

class TopNSortedArray
{
	public int MaxSize { get; }

	private List<int> _data;

	public TopNSortedArray(int maxSize)
	{
		MaxSize = maxSize;
		_data = new (MaxSize);
	}

	public void Insert(int value)
	{
		if (_data.Count == 0)
		{
			_data.Add(value);
			return;
		}
		
		var p = Find(value);
		if (_data.Count == MaxSize)
		{
			if (p != 0)
			{
				_data.RemoveAt(0);
				_data.Insert(p - 1, value);
			}
		}
		else
		{
			_data.Insert(p, value);
		}
	}

	public int Find(int value)
	{
		var l = 0;
		var r = _data.Count - 1;
		while (l <= r)
		{
			var m = (l + r) / 2;
			var d = _data[m];
			if (d == value) return m;
			if (d < value) l = m + 1;
			else r = m - 1;
		}

		return l;
	}

	public int Count => _data.Count;

	public int this[int index] => _data[index];

	public void RemoveAt(int index)
	{
		_data.RemoveAt(index);
	}
}