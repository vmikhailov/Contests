using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CodeForcesSimple.LeetCode;

[DebuggerDisplay("Count = {Count}")]
public class CircleBuffer<T> : IList<T>
	where T : IComparable<T>
{
	private int _left;
	private int _right;
	private bool _full;

	private T[] _data;

	public int MaxSize { get; }

	public CircleBuffer(int maxSize)
	{
		MaxSize = maxSize;
		_data = new T[maxSize];
	}

	public IEnumerator<T> GetEnumerator() => _data.Concat(_data).Skip(_left).Take(Count).GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	public void Add(T item)
	{
		if (Count < MaxSize)
		{
			_full = Count == MaxSize - 1;
			_data[_right] = item;
			_right = GetIndex(_right + 1);
		}
		else
		{
			if (ReleaseFor(item))
			{
				Add(item);
			}
		}
	}

	public void Clear()
	{
		_left = 0;
		_right = 0;
		_full = false;
	}

	public virtual bool Contains(T item)
	{
		return Find(item).Index >= 0;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		var i = arrayIndex;
		foreach (var item in this)
		{
			if (i >= array.Length) break;
			array[i++] = item;
		}
	}

	public bool Remove(T item)
	{
		var f = Find(item);
		if (f.Index == -1)
		{
			return false;
		}
		else
		{
			RemoveAt(f.Index);
			return true;
		}
	}

	public int Count => _full ? MaxSize : _right < _left ? _right + MaxSize - _left : _right - _left;

	public bool IsReadOnly => false;

	public int IndexOf(T item) => Find(item).Index;

	public void Insert(int index, T item)
	{
		var c = Count;
		if (c == MaxSize)
		{
			if (!ReleaseFor(item))
			{
				return;
			}
		}

		if (index > c)
		{
			throw new("Outside of the array");
		}

		if (index == 0)
		{
			_left = GetIndex(_left - 1);
			_data[_left] = item;
		}
		else if (index == c)
		{
			//_right = GetIndex(_right + 1);
			_right = (_right + 1) % MaxSize;
			_data[_right] = item;
		}
		else
		{
			var offset = _left + index;
			if (_left < _right)
			{
				Array.Copy(_data, offset, _data, offset + 1, c - index);
			}
			else
			{
				if (offset < MaxSize)
				{
					Array.Copy(_data, 0, _data, 1, _right);
					_data[0] = _data[MaxSize - 1];
					Array.Copy(_data, offset, _data, offset + 1, MaxSize - offset - 1);
				}
				else
				{
					offset -= MaxSize;
					Array.Copy(_data, offset, _data, offset + 1, _right - offset);
				}
			}

			_right = GetIndex(_right + 1);
			_data[GetIndex(_left + index)] = item;
		}

		_full = MaxSize - c == 1;
	}

	public void RemoveAt(int index)
	{
		if (Count == 0) return;

		_full = false;
		if (index == 0)
		{
			_data[_left] = default!;
			_left = GetIndex(_left + 1);
		}
		else if (index == Count - 1)
		{
			_data[GetIndex(_right - 1)] = default!;
			_right = GetIndex(_right - 1);
		}
		else
		{
			var l = _left;
			var r = _right < _left ? _right + MaxSize : _right;

			if (index < Count / 2)
			{
				for (var i = l + index - 1; i >= l; i--)
				{
					_data[GetIndex(i + 1)] = _data[GetIndex(i)];
				}

				_data[_left] = default!;
				_left = GetIndex(_left + 1);
			}
			else
			{
				for (var i = l + index + 1; i < r; i++)
				{
					_data[GetIndex(i - 1)] = _data[GetIndex(i)];
				}

				_data[GetIndex(_right - 1)] = default!;
				_right = GetIndex(_right - 1);
			}
		}
	}

	public T this[int index]
	{
		get => _data[GetIndex(index + _left)];
		set => _data[GetIndex(index + _left)] = value;
	}

	protected virtual (T? Item, int Index) Find(T item)
	{
		var i = 0;
		foreach (var it in this)
		{
			if (it.CompareTo(item) == 0) return (it, i);
			i++;
		}

		return (default, -1);
	}
	
	private int GetIndex(int index) => index < 0 ? index + MaxSize : index >= MaxSize ? index - MaxSize : index;

	protected virtual bool ReleaseFor(T item) => false;
}