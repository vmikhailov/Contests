using System.Collections;

namespace CodeForcesSimple.LeetCode;

class TopNSortedArray<T> : IEnumerable<T>
	where T : IComparable<T>
{
	public int MaxSize { get; }

	private CircleBuffer<T> _data;
	//private List<T> _data;

	public TopNSortedArray(int maxSize)
	{
		MaxSize = maxSize;
		_data = new (MaxSize);
	}
	
	private TopNSortedArray(int maxSize, IEnumerable<T> data)
	{
		MaxSize = maxSize;
		_data = new (MaxSize);
		_data.AddRange(data);
	}

	public void Add(T value)
	{
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

	public int Find(T value)
	{
		var l = 0;
		var r = _data.Count - 1;
		while (l <= r)
		{
			var m = (l + r) / 2;
			var d = _data[m];
			var c = d.CompareTo(value);
			if (c == 0) return m;
			if (c < 0) l = m + 1;
			else r = m - 1;
		}

		return l;
	}

	public int Count => _data.Count;

	public T this[int index] => _data[index];

	public void RemoveAt(int index)
	{
		_data.RemoveAt(index);
	}
	
	public TopNSortedArray<T> Clone() => new(MaxSize, _data);

	public IEnumerator<T> GetEnumerator() => _data.GetEnumerator();
	
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	
}